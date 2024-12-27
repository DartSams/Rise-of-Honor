using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    public float currHealth;
    public float maxHealth = 100f;
    Animator anim;
    //public GameObject rightHand;
    //public GameObject leftHand;
    public navAgentTest agentSelf;
    public NavMeshAgent agent;
    public GameObject navTarget;

    // Start is called before the first frame update
    void Awake()
    {
        currHealth = maxHealth;
        anim = GetComponent<Animator>();
        StartCoroutine(startMoving());
    }

    private IEnumerator startMoving()
    {
        float delay = Random.Range(0.2f, 1.5f);
        yield return new WaitForSeconds(delay);
        anim.SetBool("chase", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0)
        {
            anim.SetBool("chase", false);
            anim.SetTrigger("death");
            agentSelf.enabled = false;
            agent.enabled = false;
        }

        if (Vector3.Distance(agent.transform.position, navTarget.transform.position) <= 2.5)
        {
            anim.SetBool("chase", false);
            anim.SetTrigger("attack");
        }
        else
        {
            anim.SetBool("chase", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
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
            agent.isStopped = true;
            navTarget.GetComponent<playerManager>().addMoney(100);
        }
    }

    public void loseHealth(int amount)
    {
        if (currHealth > 0)
        {
            currHealth -= amount;
        } 
    }

    public void stopMoving()
    {
        //when the enemy has 0 current health this function changes the tag so the game manager knows its dead and disables the collider component to remove collisions
        gameObject.tag = "Untagged";
        transform.GetComponent<Animator>().enabled = false;
        transform.GetComponent<CapsuleCollider>().enabled = false;
    }

}
