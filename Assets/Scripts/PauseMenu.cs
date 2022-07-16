using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    Color selectedColor;

    [SerializeField]
    Color unselectedColor;

    [SerializeField]
    PlayerInput playerInput;

    private int currentSelection;

    private ButtonGroup buttonManager;

    private void Awake()
    {
        buttonManager = GetComponentInChildren<ButtonGroup>();
    }

    public void onPause()
    {
        buttonManager.selectInitalButton();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector2 input = context.ReadValue<Vector2>();

            if (input.y < 0)
            {
                buttonManager.next();
            }
            else if (input.y > 0)
            {
                buttonManager.previous();
            }
        }
    }

    public void Confirm(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            switch (currentSelection)
            {
                case 0:
                    unpause();
                    break;
                case 1:
                    returnToTitle();
                    break;
            }
        }
    }

    public void unpause()
    {
        playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void returnToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
