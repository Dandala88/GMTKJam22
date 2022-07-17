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
    PlayerInput playerInput;

    private ScoresMenu scoresMenu;

    private int currentSelection;

    private ButtonGroup buttonManager;
    private GameObject scoreSubMenu;
    private GameObject pauseSubMenu;

    public void Awake()
    {
        pauseSubMenu = transform.Find("Canvas/MainMenu").gameObject;
        scoreSubMenu = transform.Find("Canvas/ScoresMenu").gameObject;
    }

    public void onPause()
    {
        scoresMenu = GetComponentInChildren<ScoresMenu>();
        scoresMenu.gameObject.SetActive(false);
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
        if (context.started)
        {
            SelectOption();
        }
    }

    public void setScoreMenuActive()
    {
        pauseSubMenu.SetActive(false);
        scoreSubMenu.SetActive(true);

        buttonManager = scoreSubMenu.GetComponent<ButtonGroup>();
        buttonManager.selectInitalButton();
    }

    public void setPauseMenuActive()
    {
        scoreSubMenu.SetActive(false);
        pauseSubMenu.SetActive(true);

        buttonManager = pauseSubMenu.GetComponent<ButtonGroup>();
        buttonManager.selectInitalButton();
    }

    public void unpause()
    {
        playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
        scoresMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void resetAndUpause()
    {
        deathFloor.ResetPlayer();
        unpause();
    }

    public void returnToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void SelectOption()
    {
        buttonManager.selectActiveButton();
    }
}
