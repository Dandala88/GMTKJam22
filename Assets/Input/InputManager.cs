using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController controller;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Player");
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            controller.Move(context.ReadValue<Vector2>());
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            controller.Jump();
        }
    }
}
