using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteWheel : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float launchForce;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
            LaunchPlayer(collision.transform);
    }

    private void LaunchPlayer(Transform player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * launchForce * 100);
    }
}
