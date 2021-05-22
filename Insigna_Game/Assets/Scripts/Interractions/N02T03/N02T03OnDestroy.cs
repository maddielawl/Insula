using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N02T03OnDestroy : MonoBehaviour
{

    public GameObject page;

    private void Start()
    {
        Invoke("SetActive", 0.01f);
    }

    private void OnDestroy()
    {
        if (page != null)
        {
            page.SetActive(true);
        }
    }

    private void SetActive()
    {
        this.gameObject.SetActive(false);
        this.gameObject.GetComponent<PopupInterraction>().QuitInterraction();
    }
}
