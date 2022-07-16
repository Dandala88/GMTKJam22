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

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Menu");
        SelectOption();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Vector2 input = context.ReadValue<Vector2>();
            if(input.magnitude > 0)
            {
                currentSelection -= (int)input.y;
                if(currentSelection >= options.Length)
                    currentSelection = 0;
                else if(currentSelection < 0)
                    currentSelection = options.Length - 1;
                SelectOption();

            }
        }
    }

    public void Confirm(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            switch(currentSelection)
            {
                case 0: SceneManager.LoadScene(1, LoadSceneMode.Single); break;
                case 1: Application.Quit(); Debug.Log("Quit Game"); break;
            }
        }
    }

    private void SelectOption()
    {
        select.position = options[currentSelection].transform.position;

        foreach (TextMeshProUGUI tm in options)
            tm.color = unselectedColor;
        options[currentSelection].color = selectedColor;
    }

}
