using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class gameManager : MonoBehaviour
{
    public GameObject player;
    public int waveNum = 1;
    int waveChangeLimit = 5; //this is the limit to when should zombies become faster and stronger
    playerManager playerManager;
    public TMP_Text waveCountText;
    public TMP_Text undeadCountText;
    public TMP_Text playerMoneyText;
    public List<GameObject> zombiePrefabs;
    public List<GameObject> zombieSpawnLocations;
    public GameObject zombiePrefab;

    // Start is called before the first frame update
    void Awake()
    {
        Transform zombieLocation = getRandomFromList(zombieSpawnLocations).transform;
        GameObject zombie = chooseZombie(zombiePrefabs);
        zombie.tag = "enemy";
        Instantiate(zombie, zombieLocation).GetComponent<enemyScript>().navTarget = player;
        playerManager = player.GetComponent<playerManager>();
        for (int i = 1; i <= waveNum; i++)
        {
            StartCoroutine(spawnZombie());
        }
    }

    // Update is called once per frame
    void Update()
    {
        undeadCountText.text = "-" + GameObject.FindGameObjectsWithTag("enemy").Length.ToString();
        playerMoneyText.text = "$" + playerManager.money.ToString();
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            waveNum++;
            waveCountText.text = "Wave: " + waveNum.ToString();
            for (int i = 0; i <= waveNum; i++)
            {
                spawnZombie();
            }

            if (waveNum == waveChangeLimit)
            {
                //increase zombie move speed,health,and damage
                //then also increase the wave change limit
                waveChangeLimit += 2;
                zombiePrefab.GetComponent<NavMeshAgent>().speed = zombiePrefab.GetComponent<NavMeshAgent>().speed + 0.2f;
            }
        } //if all zombies are killed then starts a new round spawning in more zombies
    }

    public IEnumerator spawnZombie()
    {
        float delay = Random.Range(2.5f, 10f);
        yield return new WaitForSeconds(delay);
        Transform zombieLocation = getRandomFromList(zombieSpawnLocations).transform;
        GameObject zombie = chooseZombie(zombiePrefabs);
        zombie.tag = "enemy";    
        Instantiate(zombie, zombieLocation).GetComponent<enemyScript>().navTarget = player;
    }

    GameObject chooseZombie(List<GameObject> lst)
    {
        return getRandomFromList(lst);
    }

    GameObject getRandomFromList(List<GameObject> lst)
    {
        int randomIndex = Random.Range(0, lst.Count);
        GameObject item = lst[randomIndex];

        return item;
    }
}
