using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandYes : MonoBehaviour
{
    public EnvrioManager em;

    // Update is called once per frame
    void Update()
    {
        em.onisland = true;
    }
}
