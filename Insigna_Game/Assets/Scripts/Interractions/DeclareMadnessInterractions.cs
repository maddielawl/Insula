using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclareMadnessInterractions : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.madnessZoneInterractions = this.gameObject;
        GameManager.Instance.madnessInterractionsBC2D = this.gameObject.GetComponentsInChildren<BoxCollider2D>();
        GameManager.Instance.madnessInterractionsSprRend = this.gameObject.GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < GameManager.Instance.madnessInterractionsBC2D.Length; i++)
        {
            GameManager.Instance.madnessInterractionsBC2D[i].enabled = false;
        }

        for (int i = 0; i < GameManager.Instance.madnessInterractionsSprRend.Length; i++)
        {
            GameManager.Instance.madnessInterractionsSprRend[i].enabled = false;
        }
    }
}
