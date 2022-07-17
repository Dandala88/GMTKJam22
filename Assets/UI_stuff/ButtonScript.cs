using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler
{
    private Image outline;
    private TextMeshProUGUI text;
    private ButtonGroup manager;

    public void Awake()
    {
        outline = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        manager = GetComponentInParent<ButtonGroup>();
    }

    public void setActive()
    {
        if(outline != null)
            outline.enabled = true;
        if(text != null)
            text.color = new Color32(240, 85, 38, 255);
    }

    public void setInactive()
    {
        if (outline != null)
            outline.enabled = false;
        if (text != null)
            text.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        manager.setActiveButton(transform.GetInstanceID());
    }
}
