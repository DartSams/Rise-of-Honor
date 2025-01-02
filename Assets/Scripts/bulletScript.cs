using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    int bulletSpeed = 40;
    public Rigidbody rb;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        //Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * bulletSpeed); //when bullet is spawned it moved forwards in the direction of shooting
        //transform.parent = gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            //Debug.Log("enemy hit");
            //when the bullet is instantiated its made a child component of the gun the gun script has a reference to the player 
            //when the bullet enters into the enemy the player gains money

            //gunScript gun = transform.parent.gameObject.GetComponent<gunScript>();
            //gun.player.GetComponent<playerManager>().addMoney(100);
            //other.gameObject.GetComponent<enemyScript>().navTarget.GetComponent<playerManager>().addMoney(100);

            other.gameObject.GetComponent<enemyScript>().loseHealth(damage);
            //Debug.Log("enemy health is at " + other.gameObject.GetComponent<enemyScript>().currHealth);

            //Destroy(gameObject);
        } 
    }
}
