using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    float bulletSpeed = 500f;
    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        //player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    public void Shoot()
    {
        GameObject b = Instantiate(bullet, bulletSpawn.position,bulletSpawn.rotation);
        b.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed);
        b.transform.parent = gameObject.transform;
        //Destroy(bullet, 5f);
    }
}
