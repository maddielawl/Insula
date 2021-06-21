using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPopUp : MonoBehaviour
{

    public string popUpName;

    public void QuitInterraction()
    {
        GameObject.Find(popUpName).transform.GetComponent<PopupInterraction>().QuitInterraction();
        GameObject.Find(popUpName).transform.GetComponent<PopupInterraction>().DeactivateAllInteractables();
    }

    public void Deactivate()
    {
        GameObject.Find(popUpName).gameObject.SetActive(false);
        GameObject.Find("Props_F_Placard_CoffreHighlight (1)").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Props_F_Placard_CoffreHighlight (2)").GetComponent<SpriteRenderer>().enabled = true;

    }
}
