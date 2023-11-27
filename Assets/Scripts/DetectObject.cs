
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    public GameObject targetObject; // The target GameObject

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.transform.position);
        Debug.Log("Distance to target: " + distanceToTarget);
    }
}