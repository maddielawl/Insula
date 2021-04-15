using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vents : MonoBehaviour
{
    public GameObject inside;
    public GameObject outside;

    public bool isInside = false;


    public void GetInside(GameObject thenear) 
    {
        outside.SetActive(false);
        inside.SetActive(true);  
    }

    public void GetOutside(GameObject thenear)
    {
        inside.SetActive(false);
        outside.SetActive(true);        
    }

}
