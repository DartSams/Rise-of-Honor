using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject player;
    playerManager playerManager;
    public TMP_Text waveCountText;
    public TMP_Text undeadCountText;
    public TMP_Text playerMoneyText;
    public List<GameObject> zombieSpawnLocations;
    public GameObject zombiePrefab;
    public int waveNum = 1;

    // Start is called before the first frame update
    void Awake()
    {
        playerManager = player.GetComponent<playerManager>();
        for (int i = 0; i <= waveNum; i++)
        {
            spawnZombie();
        }
    }

    // Update is called once per frame
    void Update()
    {
        undeadCountText.text = GameObject.FindGameObjectsWithTag("enemy").Length.ToString();
        playerMoneyText.text = "$" + playerManager.money.ToString();
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            for (int i = 0; i <= waveNum; i++)
            {
                spawnZombie();
            }
            waveNum++;
            waveCountText.text = "Wave: " + waveNum.ToString();
        } //if all zombies are killed then starts a new round spawning in more zombies
    }

    void spawnZombie()
    {
        int randomIndex = Random.Range(0, zombieSpawnLocations.Count);
        Transform zombieLocation = zombieSpawnLocations[randomIndex].transform;

        Instantiate(zombiePrefab, zombieLocation).GetComponent<navAgentTest>().navTarget = player;

    }
}
