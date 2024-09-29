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

    // Start is called before the first frame update
    void Awake()
    {
        //player = GameObject.FindWithTag("player");
    }

    private void LateUpdate()
    {
        priceText.text = "Cost: $" + price.ToString();
    }

    // Update is called once per frame
    public void Shoot()
    {
        GameObject b = Instantiate(bullet, bulletSpawn.position,bulletSpawn.rotation); //creates a bullet when the gun is shot
        b.transform.parent = gameObject.transform; //sets the bullet to be the child of the gun
    }

    public void takePlayerMoney()
    {
        player.GetNamedChild("rightHandController").GetComponent<playerController>().pm.loseMoney(price);
    }

    public void removeText()
    {
        priceText.enabled = false; //when the gun is picked up removes the cost price of the gun
    }

}
