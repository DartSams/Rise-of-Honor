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
    float bulletSpeed = 500f;
    public GameObject player;
    public int price = 500;
    public TMP_Text priceText;

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
        GameObject b = Instantiate(bullet, bulletSpawn.position,bulletSpawn.rotation);
        //b.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed);
        //b.transform.parent = gameObject.transform;
        //Destroy(bullet, 5f);
    }

    public void takePlayerMoney()
    {
        player.GetNamedChild("rightHandController").GetComponent<playerController>().loseMoney(price);
    }

    public void removeText()
    {
        priceText.enabled = false;
    }

}
