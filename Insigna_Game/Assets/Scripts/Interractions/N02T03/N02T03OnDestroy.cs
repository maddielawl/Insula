using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N02T03OnDestroy : MonoBehaviour
{

    public GameObject page;

    private void OnDestroy()
    {
        page.SetActive(true);
    }
}
