using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAimGround : MonoBehaviour
{
    GameObject raycastOrigin;
    int layerMask;
    void Start()
    {
        layerMask = LayerMask.GetMask("ground");
        raycastOrigin = transform.parent.gameObject;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.transform.position, -transform.up, out hit, Mathf.Infinity, layerMask))
        {
            transform.position = hit.point;
        }
    }
}
