using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler
{
    private Image outline;
    private TextMeshProUGUI text;
    private ButtonGroup manager;

    private void Awake()
    {
        outline = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        manager = GetComponentInParent<ButtonGroup>();
    }

    public void setActive()
    {
        outline.enabled = true;
        text.color = new Color32(240, 85, 38, 255);
    }

    public void setInactive()
    {
        outline.enabled = false;
        text.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        manager.setActiveButton(transform.GetInstanceID());
    }
}
