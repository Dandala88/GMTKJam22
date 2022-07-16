using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] options;
    [SerializeField]
    Transform select;
    [SerializeField]
    Color selectedColor;
    [SerializeField]
    Color unselectedColor;
    [SerializeField]
    PlayerInput playerInput;

    private int currentSelection;

    private void Awake()
    {
        SelectOption();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector2 input = context.ReadValue<Vector2>();
            if (input.magnitude > 0)
            {
                currentSelection -= (int)input.y;
                if (currentSelection >= options.Length)
                    currentSelection = 0;
                else if (currentSelection < 0)
                    currentSelection = options.Length - 1;
                SelectOption();

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
                    playerInput.SwitchCurrentActionMap("Player");
                    Time.timeScale = 1;
                    gameObject.SetActive(false);
                    break;
                case 1:
                    Time.timeScale = 1;
                    SceneManager.LoadScene(0, LoadSceneMode.Single); 
                    break;
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
