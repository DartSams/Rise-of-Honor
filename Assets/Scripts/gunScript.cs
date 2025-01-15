using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class gunScript : MonoBehaviour
{
    public GameObject bullet;
    public int currClipSize;
    public int maxClipSize;
    public Transform bulletSpawn;
    public GameObject player;
    public int price;
    public TMP_Text priceText;
    public int gunDamage;
    AudioSource shotSound;
    bool isShooting;
    bool canShoot = false;
    public bool isFullAutoGun;
    public ParticleSystem muzzleGunFlash;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        //player = GameObject.FindWithTag("player");
        shotSound = GetComponent<AudioSource>();
        anim = transform.parent.GetComponent<Animator>();
    }

    private void Start()
    {
        priceText.text = "Cost: $" + price.ToString();
        currClipSize = maxClipSize;
    }
    private void FixedUpdate()
    {
        //fullAutoShot();
        if (canShoot && isFullAutoGun)
        {
            //Shoot();
            Invoke("Shoot", 0.25f);
        } 
    }

    // Update is called once per frame
    public void Shoot()
    {
        anim.SetTrigger("shoot");
        if (currClipSize > 0)
        {
            GameObject b = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.rotation); //creates a bullet when the gun is shot
            muzzleGunFlash.Play();
            //b.transform.parent = gameObject.transform; //sets the bullet to be the child of the gun
            b.GetComponent<bulletScript>().damage = gunDamage;
            if (!isFullAutoGun)
            {
                shotSound.PlayOneShot(shotSound.clip); //PlayOneShot plays audio without interrupting the previous one
            }
        }   
    }

    public void decreaseClip()
    {
        currClipSize -= 1;
    }

    public void fullAutoShot()
    {
        canShoot = true;
    }

    public void stopShooting()
    {
        canShoot = false;
    }

    public void pickupGun()
    {
        player.GetNamedChild("rightHandController").GetComponent<playerController>().pm.loseMoney(price);
        gameObject.tag = "currGun";
    }

    public void dropGun()
    {
        gameObject.tag = "Untagged";
        gameObject.transform.parent.GetComponent<Rigidbody>().useGravity = true;
    }

    public void removeText()
    {
        Destroy(priceText);
        //priceText.enabled = false; //when the gun is picked up removes the cost price of the gun
    }

    public void shootOn()
    {
        isShooting = true;
    }

    public void shootOff()
    {
        isShooting = false;
    }
}
