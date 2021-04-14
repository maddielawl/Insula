using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vents : MonoBehaviour
{
    public GameObject inside;
    public GameObject outside;




    public void GetInside(GameObject thenear) 
    {
        thenear.SetActive(false);
        outside.SetActive(false);
        inside.SetActive(true);
        
    }

    public void GetOutside(GameObject thenear)
    {
        thenear.SetActive(false);
        inside.SetActive(false);
        outside.SetActive(true);
        
    }

}
