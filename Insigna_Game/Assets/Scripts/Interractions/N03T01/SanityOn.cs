using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityOn : MonoBehaviour
{
    public EnvrioManager enviromanager;

    // Update is called once per frame
    void Update()
    {
        if(enviromanager.inMadness == true)
        {
            enviromanager.inMadness = false;
        }
    }
}
