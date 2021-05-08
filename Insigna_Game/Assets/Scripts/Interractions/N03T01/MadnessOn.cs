using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadnessOn : MonoBehaviour
{
    public EnvrioManager enviromanager;

    // Update is called once per frame
    void Update()
    {
        if (enviromanager.inMadness == false)
        {
            enviromanager.inMadness = true;
        }
    }
}
