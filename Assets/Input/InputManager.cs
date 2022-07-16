using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController controller;
    [SerializeField]
    private PauseMenu pauseMenu;
    [SerializeField]
    private float keyboardFullSpeedHoldTime;
    [SerializeField]
    private float keyboardHoldSpeed;
    [SerializeField]
    private float keyboardNoHoldSpeed;

    private PlayerInput playerInput;
    private bool keyboardHold;
    private Vector2 keyboardInput;
    private float keyboardHeld;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Player");
    }

    private void Update()
    {
        float keyboardSpeed = keyboardNoHoldSpeed;
        if (keyboardHold)
        {
            keyboardHeld += Time.deltaTime;
            keyboardSpeed = Mathf.Lerp(keyboardNoHoldSpeed, keyboardHoldSpeed, keyboardHeld / keyboardFullSpeedHoldTime);
        }
        else
            keyboardHeld = 0;

        controller.Move(keyboardInput * keyboardSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
        if ((context.started || context.performed) && playerInput.currentControlScheme == "Keyboard + Mouse")
        {
            keyboardInput = context.ReadValue<Vector2>();
            keyboardHold = true;
        }

        if (context.canceled && playerInput.currentControlScheme == "Keyboard + Mouse")
        {
            keyboardInput = Vector2.zero;
            keyboardHold = false;
        }

        if (context.performed && playerInput.currentControlScheme != "Keyboard + Mouse")
            controller.Move(context.ReadValue<Vector2>());
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            controller.Jump();
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!pauseMenu.isActiveAndEnabled)
            {
                Time.timeScale = 0;
                pauseMenu.gameObject.SetActive(true);
                playerInput.SwitchCurrentActionMap("Menu");
            }
        }
    }
}
