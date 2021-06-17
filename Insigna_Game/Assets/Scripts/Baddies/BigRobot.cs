using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRobot : MonoBehaviour
{
    public GameObject pagepopup;

    private void Start()
    {
        pagepopup.SetActive(false);
    }
    public void ActivatePage()
    {
        pagepopup.SetActive(true);
    }
}
