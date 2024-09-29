using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public playerManager playerManager;
    public TMP_Text undeadCountText;
    public TMP_Text playerMoneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        undeadCountText.text = "Undead Left: " + GameObject.FindGameObjectsWithTag("enemy").Length;
        playerMoneyText.text = "Money: $" + playerManager.money.ToString();
    }
}
