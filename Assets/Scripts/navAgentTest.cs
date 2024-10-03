using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navAgentTest : MonoBehaviour
{
    public GameObject navTarget;
    NavMeshAgent agent;
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((Vector3.Distance(transform.position, navTarget.transform.position)));
        if (Vector3.Distance(transform.position,navTarget.transform.position) > 2.2f)
        {
            anim.SetBool("chase", true);
            agent.SetDestination(navTarget.transform.position);
        } 

        if (Vector3.Distance(transform.position, navTarget.transform.position) < 2)
        {
            anim.SetBool("chase", false);
            anim.SetTrigger("attack");
        }


    }


}
