using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    private float minSphereColliderSize;

    [SerializeField]
    private float maxSphereColliderSize;

    [SerializeField]
    private float shapeShiftSpeed;

    [SerializeField]
    private float maxAngularVelocityPower;

    [SerializeField]
    private float moveForce;

    [SerializeField]
    private float jumpForce;

    private Rigidbody rb;
    private Vector2 input;

    private SphereCollider sphereCollider;

    private bool isRolling;

    public bool getRollingStatus()
    {
        return isRolling;
    }

    private void Awake()
    {
        isRolling = false;
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        rb.maxAngularVelocity = 10 * (maxAngularVelocityPower * maxAngularVelocityPower);
    }

    void Start()
    {
        //this fixes the torque for mesh colliders
        rb.inertiaTensor = new Vector3(1, 1, 1);
    }

    public void Move(Vector2 sentInput)
    {
        input = sentInput;
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Vector3 translatedInput = new Vector3(input.y, 0f, -input.x);
        translatedInput =
            Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up)
            * translatedInput;
        rb.AddTorque(translatedInput * moveForce, ForceMode.Acceleration);

        //Javascript people be like; Check if velocity and target direction and the same and that the key board is active.
        //If so, the target for the lerp is set to the max size. Else it is set for the minimum size. Helps give more of the corner physics when turning around

        float targetRadius =
            (
                translatedInput.magnitude > .1
                && Vector3.Dot(
                    new Vector3(-translatedInput.z, 0, translatedInput.x).normalized,
                    new Vector3(rb.velocity.x, 0, rb.velocity.z).normalized
                ) > 0
            )
                ? maxSphereColliderSize
                : minSphereColliderSize;

        sphereCollider.radius = Mathf.Lerp(
            sphereCollider.radius,
            targetRadius,
            shapeShiftSpeed * Time.deltaTime
        );
        isRolling = Mathf.Abs(sphereCollider.radius - maxSphereColliderSize) < .05;
        ;
    }
}
