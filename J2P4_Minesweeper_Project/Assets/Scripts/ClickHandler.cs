using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent leftClick;
    public UnityEvent middleClick;
    public UnityEvent rightClick;

    protected virtual void Start()
    {
        leftClick.AddListener(LeftClick);
        middleClick.AddListener(MiddleClick);
        rightClick.AddListener(RightClick);
    }
    void OnMouseUpAsButton()
    {
        if (Input.GetMouseButton(0)) // Left click
        {
            LeftClick();
        }
        else if (Input.GetMouseButton(1)) // Right click
        {
            MiddleClick();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            leftClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Middle)
            middleClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Right)
            rightClick.Invoke();
    }
        
    protected virtual void LeftClick() {}
    protected virtual void MiddleClick() {}
    protected virtual void RightClick() {}
}
