using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public DeathFloor deathFloor;

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

    private ScoresMenu scoresMenu;

    private int currentSelection;

    private void Awake()
    {
        scoresMenu = GetComponentInChildren<ScoresMenu>();
        scoresMenu.gameObject.SetActive(false);
        SelectOption();
    }

    private void OnEnable()
    {
        currentSelection = 0;
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
            if (scoresMenu.gameObject.activeSelf)
            {
                HideShowText(true);
                scoresMenu.gameObject.SetActive(false);
                currentSelection = 1;
                SelectOption();
            }
            else
            {

                switch (currentSelection)
                {
                    case 0:
                        playerInput.SwitchCurrentActionMap("Player");
                        Time.timeScale = 1;
                        gameObject.SetActive(false);
                        deathFloor.ResetPlayer();
                        break;
                    case 1:
                        HideShowText(false);
                        scoresMenu.gameObject.SetActive(true);
                        break;
                    case 2:
                        playerInput.SwitchCurrentActionMap("Player");
                        Time.timeScale = 1;
                        gameObject.SetActive(false);
                        break;
                    case 3:
                        Time.timeScale = 1;
                        SceneManager.LoadScene(0, LoadSceneMode.Single);
                        break;
                }
            }
        }
    }

    private void HideShowText(bool show)
    {
        foreach (TextMeshProUGUI t in options)
            t.enabled = show;
        select.gameObject.SetActive(show);
    }

    private void SelectOption()
    {
        if (!scoresMenu.gameObject.activeSelf)
        {
            select.position = options[currentSelection].transform.position;

            foreach (TextMeshProUGUI tm in options)
                tm.color = unselectedColor;
            options[currentSelection].color = selectedColor;
        }
    }
}
