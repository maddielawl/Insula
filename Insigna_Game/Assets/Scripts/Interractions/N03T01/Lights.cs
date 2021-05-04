using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{

    public bool light = false;

    public GameObject lightsOn;
    public GameObject lightsOff;

    public void ActiveLights()
    {
        if(light == false)
        {
            lightsOn.SetActive(true);
            lightsOff.SetActive(false);
            light = true;
        }
        else
        {
            lightsOn.SetActive(false);
            lightsOff.SetActive(true);
            light = false;
        }
    }
}
