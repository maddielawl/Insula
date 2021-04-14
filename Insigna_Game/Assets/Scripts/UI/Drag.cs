using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Canvas canvas;
    private RectTransform rectTransform;
    [HideInInspector]
    public CanvasGroup canvasGroup;

    [HideInInspector]
    public Vector2 iniRectTransform;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        iniRectTransform = rectTransform.anchoredPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        CursorManager.Instance.rend.sprite = CursorManager.Instance.grabCursor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        CursorManager.Instance.rend.sprite = CursorManager.Instance.cursor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorManager.Instance.rend.sprite = CursorManager.Instance.takeCursor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.Instance.rend.sprite = CursorManager.Instance.cursor;
    }
}
