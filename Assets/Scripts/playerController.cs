using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class playerController : MonoBehaviour
{
    public playerManager pm;
    public float currHealth;
    public float maxHealth = 100f;


    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
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
            //Debug.Log("Picked up " + (pm.money<gun.price).ToString() +gun.price + "my money is " + pm.money);
            if (pm.money >= gun.price)
            {
                other.gameObject.transform.parent.GetComponent<XRGrabInteractable>().enabled = true;
                //other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
                //Debug.Log("Picked up " + other.gameObject.name);
                //loseMoney();
            }
            if (pm.money < gun.price)
            {
                other.gameObject.transform.parent.GetComponent<XRGrabInteractable>().enabled = false;
            }
        }
        else
        {
            //
        }
    }
}
