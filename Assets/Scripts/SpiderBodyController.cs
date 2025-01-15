using UnityEngine;

public class SpiderBodyController : MonoBehaviour
{
    public SpiderLegConstraint[] legs;
    public float bodyHeight = 1.5f; 
    public float bodySmoothness = 5.0f; 

    private Vector3 targetBodyPosition;

    void Update()
    {
        Vector3 averageLegPosition = Vector3.zero;
        foreach (var leg in legs)
        {
            averageLegPosition += leg.IKTarget.position;
        }
        averageLegPosition /= legs.Length;

        targetBodyPosition = averageLegPosition + Vector3.up * bodyHeight;
        transform.position = Vector3.Lerp(transform.position, targetBodyPosition, Time.deltaTime * bodySmoothness);
    }
}
