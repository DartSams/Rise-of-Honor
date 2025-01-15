using UnityEngine;

public class SpiderLegConstraint : MonoBehaviour
{
    public Transform IKTarget; 
    public Transform defaultPosition;
    public LayerMask groundLayer; 
    public float stepDistance = 1.0f;
    public float stepHeight = 0.5f; 
    public float moveSpeed = 5.0f; 

    private bool isStepping = false;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = defaultPosition.position;
        IKTarget.position = defaultPosition.position;
    }

    void Update()
    {
        if (!isStepping)
        {
            float distanceToDefault = Vector3.Distance(IKTarget.position, defaultPosition.position);
            if (distanceToDefault > stepDistance)
            {
                StartCoroutine(Step());
            }
        }
    }

    private System.Collections.IEnumerator Step()
    {
        isStepping = true;

        if (Physics.Raycast(defaultPosition.position + Vector3.up, Vector3.down, out RaycastHit hit, 2.0f, groundLayer))
        {
            targetPosition = hit.point;
        }

        Vector3 startPosition = IKTarget.position;
        float stepProgress = 0.0f;
        while (stepProgress < 1.0f)
        {
            stepProgress += Time.deltaTime * moveSpeed;
            float heightOffset = Mathf.Sin(stepProgress * Mathf.PI) * stepHeight;
            IKTarget.position = Vector3.Lerp(startPosition, targetPosition, stepProgress) + Vector3.up * heightOffset;
            yield return null;
        }

        IKTarget.position = targetPosition;
        isStepping = false;
    }
}
