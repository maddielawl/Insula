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
    }
}
