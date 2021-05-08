using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IleQuiMeurt : MonoBehaviour
{
    public EnvrioManager em;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");

        if (em.inMadness == true && em.phareonoroff == true && em.dayornight == true && collision.CompareTag("Waypoint 1"))
        {
            Destroy(this.gameObject);
        }
    }

}
