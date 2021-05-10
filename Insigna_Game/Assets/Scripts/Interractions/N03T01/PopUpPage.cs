using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPage : MonoBehaviour
{
    public GameObject sanity;
    public GameObject madness;

    public EnvrioManager em;

    private void Start()
    {
        em = GameObject.FindGameObjectWithTag("Waypoint 4").transform.GetComponent<EnvrioManager>();
    }

    void Update()
    {
        if(em == null)
        {
            em = GameObject.FindGameObjectWithTag("Waypoint 4").transform.GetComponent<EnvrioManager>();
        }
        if(em.inMadness == true)
        {
            madness.SetActive(true);
            sanity.SetActive(false);
        }
        else
        {
            madness.SetActive(false);
            sanity.SetActive(true);
        }
    }
}
