using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTracker : MonoBehaviour
{
    [SerializeField]
    Transform moving;

    [SerializeField]
    float threshhold;
    private Vector3 previousPosition;

    void Awake()
    {
        transform.position = moving.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 direction = moving.transform.position - previousPosition;
        if (direction.magnitude > threshhold)
        {
            transform.forward = direction;
            previousPosition = moving.transform.position;
        }
    }
}
