using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHighlight : MonoBehaviour
{
    public GameObject highlight;
    public GameObject noHighlight;

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
        noHighlight.SetActive(false);
    }
    private void OnMouseExit()
    {
        highlight.SetActive(false);
        noHighlight.SetActive(true);
    }
}
