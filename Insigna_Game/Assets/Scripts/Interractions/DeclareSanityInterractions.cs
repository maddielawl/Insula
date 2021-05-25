using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclareSanityInterractions : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.sanityZoneInterractions = this.gameObject;
        GameManager.Instance.sanityInterractionsBC2D = this.gameObject.GetComponentsInChildren<BoxCollider2D>();
        GameManager.Instance.sanityInterractionsSprRend = this.gameObject.GetComponentsInChildren<SpriteRenderer>();
        
        for (int i = 0; i < GameManager.Instance.sanityInterractionsBC2D.Length; i++)
        {
            GameManager.Instance.sanityInterractionsBC2D[i].enabled = true;
            if(GameManager.Instance.sanityInterractionsBC2D[i].gameObject.name == "HelmetEquip")
            {
                GameManager.Instance.sanityInterractionsBC2D[i].enabled = false;
            }
        }

        for (int i = 0; i < GameManager.Instance.sanityInterractionsSprRend.Length; i++)
        {
            GameManager.Instance.sanityInterractionsSprRend[i].enabled = true;
        }
    }
}
