using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    //public navAgentTest agentSelf;
    public NavMeshAgent agent;
    public GameObject navTarget;
    public bool alive;
    //int deathAnimation;
    public GameObject bloodSplatterEffect;
    public bool isCrawling;
    public GameObject powerUp;

    List<GameObject> powerUpChanceList = new List<GameObject>(new GameObject[8]); //8 items in list so has a 1 in 8 chance of dropping a powerUp from the list of null values


    // Start is called before the first frame update
    void Awake()
    {
        setRigidBodyState(true);
        setColliderState(false);
        alive = true;
        currHealth = maxHealth;
        anim = GetComponent<Animator>();
        StartCoroutine(startMoving());
        //deathAnimation = Random.Range(1, 3);
    }

    private void Start()
    {
        powerUpChanceList[Random.Range(0, powerUpChanceList.Count)] = powerUp.gameObject; //updates the zombie powerUpChanceList

    }

    private IEnumerator startMoving()
    {
        float delay = Random.Range(0.2f, 1.5f);
        yield return new WaitForSeconds(delay);
        //anim.SetBool("chase", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0)
        {
            Die();
        } //added this here for testing purposes

        if (Vector3.Distance(agent.transform.position, navTarget.transform.position) <= 2)
        {
            anim.SetBool("chase", false);
            anim.SetTrigger("attack");
        }
        if (alive && (Vector3.Distance(agent.transform.position, navTarget.transform.position) >= 2.01) && isCrawling == false)
        {
            anim.SetBool("chase", true);
            agent.SetDestination(navTarget.transform.position);
        } else if (alive && Vector3.Distance(agent.transform.position, navTarget.transform.position) >= 2.01 && isCrawling == true)
        {
            anim.SetBool("crawl", true);
            agent.SetDestination(navTarget.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "player")
        {
            //Debug.Log("Player Hit");
        }

        if (other.gameObject.tag == "bullet")
        {
            //Debug.Log("Target has been hit");
            anim.SetTrigger("takeHit");
            //agent.isStopped = true;
            navTarget.GetComponent<playerManager>().addMoney(100);

            Vector3 hitPoint = other.ClosestPointOnBounds(transform.position);  // Get the closest point on the zombie's collider
            Vector3 bloodDirection = hitPoint - transform.position; // Direction from zombie to the impact point
            Destroy(other.gameObject);
            GameObject bloodEffect = Instantiate(bloodSplatterEffect, hitPoint, Quaternion.LookRotation(bloodDirection));

            bloodEffect.transform.Rotate(90f, 0f, 0f); 
        }
    }

    public void loseHealth(int amount)
    {
        if (currHealth > 0)
        {
            currHealth -= amount;
        }

        if (currHealth <= 0)
        {
            Die();
            dropLoot();
        }
    }

    void dropLoot()
    {
        int lootChance = Random.Range(0, powerUpChanceList.Count);
        //Debug.Log("loot spawned was: " + powerUpChanceList[lootChance]);
        if (powerUpChanceList[lootChance] != null)
        {
            //Debug.Log("spawned");
            //spawn the powerUp
            GameObject p = Instantiate(powerUp, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            p.transform.parent = transform;
        }
    }

    void Die()
    {
        //dropLoot(); //added this here for testing purposes
        alive = false;
        anim.SetBool("chase", false);
        anim.SetBool("crawl", false);
        //agentSelf.enabled = false;
        agent.enabled = false;
        //trigger death animation

        //if (deathAnimation == 1)
        //{
            //anim.SetTrigger("death 1");
        //}
        //else
        //{
            //anim.SetTrigger("death 2");
        //}
        GetComponent<Animator>().enabled = false;
        //enter ragdoll state
        setRigidBodyState(false);
        setColliderState(true);
        gameObject.tag = "Untagged"; //when the enemy has 0 current health this changes the tag so the game manager knows its dead and disables the collider component to remove collisions
        StartCoroutine(removeBody());
    }

    void setRigidBodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    void setColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider c in colliders)
        {
            c.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }

    public IEnumerator removeBody()
    {
        float delay = Random.Range(10f, 30f);
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    } //removes the dead zombie from the world for optimization
}
