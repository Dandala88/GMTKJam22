using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform follow;

    private void Update()
    {
        transform.position = follow.position + offset;

        transform.LookAt(follow);
    }
}
