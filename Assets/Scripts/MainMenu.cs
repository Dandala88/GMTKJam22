using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Transform[] options;

    private PlayerInput playerInput;

    private int currentSelection;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Menu");
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            if(input.magnitude > 0)
            {
                currentSelection = (int)Mathf.Clamp(currentSelection + input.y, 0, 1);
                Debug.Log(currentSelection);
            }
        }
    }

    public void Confirm(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Yup");
        }
    }

}
