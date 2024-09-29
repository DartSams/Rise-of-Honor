using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class playerController : MonoBehaviour
{
    public int money = 0; //will be used for buy ammo and weapons
    public float currHealth = 100f;
    public float maxHealth;
    int minGunPrice = 500;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "interactable")
        {
            gunScript gun = other.gameObject.GetComponent<gunScript>();
            Debug.Log("Picked up " + (money<gun.price).ToString() +gun.price + "my money is " + money);
            if (money >= gun.price)
            {
                other.gameObject.transform.parent.GetComponent<XRGrabInteractable>().enabled = true;
                //other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
                Debug.Log("Picked up " + other.gameObject.name);
                //loseMoney();
            }
            if (money < gun.price)
            {
                other.gameObject.transform.parent.GetComponent<XRGrabInteractable>().enabled = false;
            }
        }
        else
        {
            //
        }
    }

    public void addMoney(int cost)
    {
        money += cost;
    }

    public void loseMoney(int cost)
    {
        money -= cost;
    }
}
