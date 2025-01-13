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
}
