using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sentryController : MonoBehaviour
{
    public GameObject bullet;
    public int currClipSize;
    public int maxClipSize;
    public Transform bulletSpawn;
    public int gunDamage;
    AudioSource shotSound;
    private bool isShooting = false;
    public ParticleSystem muzzleGunFlash;

    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
        currClipSize = maxClipSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("sentry detected: " + collision.gameObject.name);
        if (collision.gameObject.tag == "enemy" && !isShooting)
        {
            //transform.LookAt(collision.transform.position);
            Vector3 direction = collision.gameObject.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(-direction, Vector3.up);
            Vector3 eulerAngles = rotation.eulerAngles;
             
            eulerAngles.x = -4f; 

            eulerAngles.z = 0f; 

            transform.rotation = Quaternion.Euler(eulerAngles); 

            StartCoroutine(Shoot());
        }
    }


    IEnumerator Shoot()
    {
        isShooting = true;
        yield return new WaitForSeconds(0.2f);
        if (currClipSize > 0)
        {
            GameObject b = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.rotation); //creates a bullet when the gun is shot
            //b.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 40);
            muzzleGunFlash.Play();
            //b.transform.parent = gameObject.transform; //sets the bullet to be the child of the gun
            b.GetComponent<bulletScript>().damage = gunDamage;
            shotSound.PlayOneShot(shotSound.clip); //PlayOneShot plays audio without interrupting the previous one
            decreaseClip();
        }
        isShooting = false;
    }

    public void decreaseClip()
    {
        currClipSize -= 1;
    }
}
