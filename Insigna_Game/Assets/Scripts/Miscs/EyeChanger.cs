using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EyeChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image eyeSpr;
    public Sprite eyeNormal;
    public Sprite eyeDirection;
    public void OnPointerEnter(PointerEventData eventData)
    {
        eyeSpr.sprite = eyeDirection;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        eyeSpr.sprite = eyeNormal;
    }
}
