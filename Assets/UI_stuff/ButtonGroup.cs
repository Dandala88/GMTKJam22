using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonGroup : MonoBehaviour
{
    public ButtonScript[] managedButtons;
    public int activeButtonIndex;

    public void selectInitalButton()
    {
        activeButtonIndex = managedButtons[0].transform.GetInstanceID();
        setActiveButton(activeButtonIndex);
    }

    private void Awake()
    {
        managedButtons = GetComponentsInChildren<ButtonScript>();
        selectInitalButton();
    }

    public void next()
    {
        bool run = false;
        foreach (ButtonScript button in managedButtons)
        {
            if (run)
            {
                setActiveButton(button.transform.GetInstanceID());
                break;
            }
            if (button.transform.GetInstanceID() == activeButtonIndex)
            {
                run = true;
            }
        }
    }

    public void previous()
    {
        int idToSet = -1;
        foreach (ButtonScript button in managedButtons)
        {
            if (button.transform.GetInstanceID() == activeButtonIndex)
            {
                if (idToSet == -1)
                    break;
                setActiveButton(idToSet);
                break;
            }
            idToSet = button.transform.GetInstanceID();
        }
    }

    public void setActiveButton(int index)
    {
        activeButtonIndex = index;
        foreach (ButtonScript button in managedButtons)
        {
            if (index == button.transform.GetInstanceID())
            {
                button.setActive();
            }
            else
            {
                button.setInactive();
            }
        }
    }

    public ButtonScript getActiveButton()
    {
        return Array.Find(
            managedButtons,
            (ele) =>
            {
                return ele.transform.GetInstanceID() == activeButtonIndex;
            }
        );
    }

    public void selectActiveButton()
    {
        getActiveButton().transform.GetComponent<Button>().onClick.Invoke();
    }
}
