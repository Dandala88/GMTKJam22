using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] options;

    [SerializeField]
    Transform select;

    [SerializeField]
    Color selectedColor;

    [SerializeField]
    Color unselectedColor;

    private PlayerInput playerInput;

    private int currentSelection;
    private ButtonGroup buttonManager;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Menu");
        buttonManager = GetComponentInChildren<ButtonGroup>();
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
        buttonManager.selectActiveButton();
    }

    private void SelectOption()
    {
        select.position = options[currentSelection].transform.position;

        foreach (TextMeshProUGUI tm in options)
            tm.color = unselectedColor;
        options[currentSelection].color = selectedColor;
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
