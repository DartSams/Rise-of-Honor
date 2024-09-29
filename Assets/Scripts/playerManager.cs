using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public int money = 0; //will be used for buy ammo and weapons
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
