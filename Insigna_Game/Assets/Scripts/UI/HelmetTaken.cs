using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetTaken : MonoBehaviour
{
    private SpriteRenderer ordureSprite;
    private GameObject helmetInteraction;
    public Sprite ordureWithTV;

    public void Update()
    {
        if (GameObject.Find("L01_T03_TV").GetComponent<SpriteRenderer>() != null)
        {
            ordureSprite = GameObject.Find("L01_T03_TV").GetComponent<SpriteRenderer>();
        }

        if (GameObject.Find("HelmetEquip") != null)
        {
            helmetInteraction = GameObject.Find("HelmetEquip");
        }
    }

    //Quand on récupère la télé dans le mini jeu
    public void HelmetTook()
    {
        transform.parent.GetComponent<QuitPopUp>().QuitInterraction();
        transform.parent.GetComponent<QuitPopUp>().Deactivate();
        ordureSprite.sprite = ordureWithTV;
        helmetInteraction.SetActive(true);
        helmetInteraction.GetComponent<BoxCollider2D>().enabled = true;
    }
}
