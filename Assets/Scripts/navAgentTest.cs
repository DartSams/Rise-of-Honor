using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navAgentTest : MonoBehaviour
{
    public GameObject navTarget;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(navTarget.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "player")
        {
            Debug.Log("Player Hit");
        }
    }
}
