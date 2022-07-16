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
