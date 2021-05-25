using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyWoder : MonoBehaviour
{
    public GameObject woder;
    public GameObject foliewoder;
    public GameObject ladder1;
    public GameObject ladder2;

    private void Start()
    {
        Invoke("SetActive", 0.01f);
    }

    private void OnDestroy()
    {
        woder.SetActive(false);
        foliewoder.SetActive(false);
        ladder1.SetActive(false);
        ladder2.SetActive(true);
    }

    private void SetActive()
    {
        this.gameObject.SetActive(false);
        this.gameObject.GetComponent<PopupInterraction>().QuitInterraction();
    }
}
