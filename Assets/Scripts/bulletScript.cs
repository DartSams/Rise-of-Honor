using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    int bulletSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        transform.parent = gameObject.transform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "gun")
        {
            Destroy(gameObject,1.5f);
        }

        if (collision.gameObject.tag == "enemy")
        {
            //increase the player money value
        }
    }
}
