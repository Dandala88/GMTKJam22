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
    Color selectedColor;

    [SerializeField]
    Color unselectedColor;

    [SerializeField]
    PlayerInput playerInput;

    private ScoresMenu scoresMenu;

    private int currentSelection;

    private ButtonGroup buttonManager;

    private void Awake()
    {
        buttonManager = GetComponentInChildren<ButtonGroup>();
    }

    public void onPause()
    {
        buttonManager.selectInitalButton();
        scoresMenu = GetComponentInChildren<ScoresMenu>();
        scoresMenu.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        currentSelection = 0;
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
