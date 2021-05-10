using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyPart1 : MonoBehaviour
{

    public GameObject part2;

    private void Start()
    {
        Invoke("SetActive", 0.01f);
    }

    private void OnDestroy()
    {
        part2.SetActive(true);
    }

    private void SetActive()
    {
        this.gameObject.SetActive(false);
        this.gameObject.GetComponent<PopupInterraction>().QuitInterraction();
    }

}
