using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private PlayerInput playerInput;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Menu");
    }

    public void Confirm(InputAction.CallbackContext context)
    {
        if(context.started)
            SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
