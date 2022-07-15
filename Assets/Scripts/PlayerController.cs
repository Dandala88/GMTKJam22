using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveScale;
    [SerializeField]
    public float moveForce;
    [SerializeField]
    public float jumpForce;

    private Rigidbody rb;
    private Vector2 input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 sentInput)
    {
        Debug.Log(sentInput);
        input = sentInput;
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }

    private void FixedUpdate()
    {
        Vector3 translatedInput = new Vector3(input.y, 0f, -input.x);
        Vector3 translatedInputMove = new Vector3(input.x, 0f, input.y);

        rb.AddForce(translatedInputMove * moveForce * moveScale);
        rb.AddTorque(translatedInput * moveForce);
    }
}
