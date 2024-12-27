using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public GameObject player;
    public int price;
    public TMP_Text priceText;
    public int gunDamage;
    AudioSource shotSound;
    bool isShooting;
    bool canShoot = false;
    public bool isSemiAutoGun;
    public bool isFullAutoGun;

    // Start is called before the first frame update
    void Awake()
    {
        //player = GameObject.FindWithTag("player");
        shotSound = GetComponent<AudioSource>();
        priceText.text = "Cost: $" + price.ToString();
    }

    private void FixedUpdate()
    {
        //fullAutoShot();
        if (canShoot && isFullAutoGun)
        {
            Invoke("Shoot", 0.25f);
        } 
    }

    // Update is called once per frame
    public void Shoot()
    {
        GameObject b = Instantiate(bullet, bulletSpawn.position,bulletSpawn.rotation); //creates a bullet when the gun is shot
        //b.transform.parent = gameObject.transform; //sets the bullet to be the child of the gun
        b.GetComponent<bulletScript>().damage = gunDamage;
        if (!isFullAutoGun)
        {
            shotSound.PlayOneShot(shotSound.clip); //PlayOneShot plays audio without interrupting the previous one
        }
    }

    public void semiAutoShot()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject b = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation); //creates a bullet when the gun is shot
            b.transform.parent = gameObject.transform; //sets the bullet to be the child of the gun
        }
        //shotSound.Play();
    }

    public void fullAutoShot()
    {
        canShoot = true;
    }

    public void stopShooting()
    {
        canShoot = false;
    }

    public void takePlayerMoney()
    {
        player.GetNamedChild("rightHandController").GetComponent<playerController>().pm.loseMoney(price);
    }

    public void removeText()
    {
        priceText.enabled = false; //when the gun is picked up removes the cost price of the gun
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
