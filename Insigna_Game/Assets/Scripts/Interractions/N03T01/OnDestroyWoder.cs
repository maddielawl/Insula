using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyWoder : MonoBehaviour
{
    public GameObject woder;

    private void Start()
    {
        Invoke("SetActive", 0.01f);
    }

    private void OnDestroy()
    {
        woder.SetActive(false);
    }

    private void SetActive()
    {
        this.gameObject.SetActive(false);
        this.gameObject.GetComponent<PopupInterraction>().QuitInterraction();
    }
}
