using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{

    public bool light = false;

    public GameObject lightsOn;
    public GameObject lightsOff;

    public bool isphareoujour;

    public EnvrioManager em;

    public void ActiveLights()
    {
        if(light == false)
        {
            if (em.electricity == true)
            {
                lightsOn.SetActive(true);
                lightsOff.SetActive(false);
                light = true;
                if(isphareoujour == false)
                {
                    em.phareonoroff = true;
                }
                else
                {
                    em.dayornight = false;
                }
            }
        }
        else
        {
            if (em.electricity == true)
            {
                lightsOn.SetActive(false);
                lightsOff.SetActive(true);
                light = false;
                if (isphareoujour == false)
                {
                    em.phareonoroff = false;
                }
                else
                {
                    em.dayornight = true;
                }
            }
        }
    }
}
