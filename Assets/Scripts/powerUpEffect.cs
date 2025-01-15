using UnityEngine;

public class powerUpEffect : MonoBehaviour
{
    public float rotationSpeed = 50f; 
    public float maxHeight = 0.5f; 
    public float moveSpeed = 1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "nuke")
        {
            Debug.Log("All zombies killed");
            Destroy(gameObject);
            GameObject[] allZombies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject zombie in allZombies)
            {
                zombie.GetComponent<enemyScript>().currHealth = 0;
            }
        } //kills all zombies when picked up

        if (gameObject.name == "fullAmmo")
        {
            //give current gun full ammo
            gunScript currentGun = GameObject.FindWithTag("currGun").GetComponent<gunScript>();
            currentGun.currClipSize = currentGun.maxClipSize;
        } //refills current guns ammo
    }
}
