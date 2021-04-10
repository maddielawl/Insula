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
        if (MenusManager.instance.inGame == true)
        {
            //ordureSprite = GameObject.FindGameObjectWithTag("OrdureTV").GetComponent<SpriteRenderer>();
            //helmetInteraction = GameObject.Find("HelmetEquip");
        }
    }
    public void HelmetTook()
    {
        UIManager.Instance.GotHelmet();
        transform.parent.GetComponent<QuitPopUp>().QuitInterraction();
        transform.parent.GetComponent<QuitPopUp>().Deactivate();
        //ordureSprite.sprite = ordureWithTV;
        //helmetInteraction.SetActive(true);
    }
}
