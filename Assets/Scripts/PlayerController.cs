using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform cam;
    [SerializeField]
    private float minSphereColliderSize;
    [SerializeField]
    private float maxSphereColliderSize;
    [SerializeField]
    private float maxAngularVelocityPower;
    [SerializeField]
    public float moveForce;
    [SerializeField]
    public float jumpForce;

    private Rigidbody rb;
    private Vector2 input;

    private SphereCollider sphereCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        rb.maxAngularVelocity = 10 * (maxAngularVelocityPower * maxAngularVelocityPower);
    }

    public void Move(Vector2 sentInput)
    {
        input = sentInput;
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }

    private void FixedUpdate()
    {
        Vector3 translatedInput = new Vector3(input.y, 0f, -input.x);
        translatedInput = Quaternion.AngleAxis(cam.rotation.eulerAngles.y, Vector3.up) * translatedInput;
        rb.AddTorque(translatedInput * moveForce, ForceMode.Acceleration);
        sphereCollider.radius = Mathf.Lerp(minSphereColliderSize, maxSphereColliderSize, input.magnitude);
    }
}
