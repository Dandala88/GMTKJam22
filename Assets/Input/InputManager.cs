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

#if !UNITY_EDITOR
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#endif
    }

    private void Update()
    {
        float keyboardSpeed = keyboardNoHoldSpeed;

        controller.Move(keyboardInput);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            keyboardInput = context.ReadValue<Vector2>();
            keyboardHold = true;
        }

        if (context.canceled)
        {
            keyboardInput = Vector2.zero;
            keyboardHold = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
#if UNITY_EDITOR
            controller.Jump();
#endif
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
                pauseMenu.onPause();
                playerInput.SwitchCurrentActionMap("Menu");
            }
        }
    }
}
