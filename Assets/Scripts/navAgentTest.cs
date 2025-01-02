using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navAgentTest : MonoBehaviour
{
    public GameObject navTarget;
    NavMeshAgent agent;
    Animator anim;
    private bool canMove = false;
    float timer;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        StartCoroutine(startMoving());
    }

    private IEnumerator startMoving()
    {
        float delay = Random.Range(0.2f, 1.5f);
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(agent.transform.position, navTarget.transform.position) <= 2.5)
        {
            canMove = false;
            anim.SetBool("chase", false);
            anim.SetTrigger("attack");
        }
        else
        {
            canMove = true;
        }

        if (canMove)
        {
            anim.SetBool("chase", true);
            agent.SetDestination(navTarget.transform.position);
        }

        if (canMove == false)
        {
            agent.SetDestination(agent.transform.position); 
        }

        if (agent.isStopped == true)
        {
            timer += Time.deltaTime;
            if (timer > 3.1f)
            {
                agent.isStopped = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "player")
        {
            Debug.Log("Player Hit");
        }

        if (other.gameObject.tag == "bullet")
        {
            Debug.Log("Target has been hit");
            anim.SetTrigger("takeHit");
        }
    }


}
