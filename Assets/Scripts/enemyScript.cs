using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float currHealth;
    public float maxHealth = 100f;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        currHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currHealth <= 0)
        {
            anim.SetTrigger("death");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("Target has been hit");
            
        }
    }

    public void loseHealth(int amount)
    {
        currHealth -= amount;
    }

    public void stopMoving()
    {
        //when the enemy has 0 current health this function changes the tag so the game manager knows its dead and disables the collider component to remove collisions
        gameObject.tag = "Untagged";
        transform.GetComponent<Animator>().enabled = false;
        transform.GetComponent<CapsuleCollider>().enabled = false;
    }
}
