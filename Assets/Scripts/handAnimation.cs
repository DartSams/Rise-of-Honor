using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class handAnimation : MonoBehaviour
{
    [SerializeField] private InputActionReference gripReference;
    [SerializeField] private InputActionReference triggerReference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float gripValue = gripReference.action.ReadValue<float>();

        float triggerValue = triggerReference.action.ReadValue<float>();
        if (gripValue > 0.0f)
        {
            Debug.Log("grip value of " + transform.name + " is " + gripValue);

        }

        if (triggerValue > 0.0f)
        {
            Debug.Log("trigger value of " + transform.name + " is "+ triggerValue);
        }
    }
}
