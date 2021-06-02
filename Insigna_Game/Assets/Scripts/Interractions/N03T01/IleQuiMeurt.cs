using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IleQuiMeurt : MonoBehaviour
{
    public EnvrioManager em;
    public GameObject pagepopup;

    // Update is called once per frame
    void Update()
    {
        if (em.inMadness == true && em.phareonoroff == true && em.dayornight == true && em.onisland == true)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        pagepopup.SetActive(true);
    }
}
