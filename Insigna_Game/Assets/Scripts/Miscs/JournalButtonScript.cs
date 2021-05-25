using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JournalButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator journalButtonAnimator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        journalButtonAnimator.SetTrigger("Depliage");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        journalButtonAnimator.SetTrigger("Repliage");
    }
}
