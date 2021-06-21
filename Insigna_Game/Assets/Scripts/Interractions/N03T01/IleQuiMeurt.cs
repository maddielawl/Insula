using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IleQuiMeurt : MonoBehaviour
{
    public EnvrioManager em;
    public GameObject grosRobotGO;
    public Animator grosRobotWithAnim;
    private bool once;

    private void Start()
    {
        once = true;
        grosRobotGO.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (em.inMadness == true && em.phareonoroff == true && em.dayornight == true && em.onisland == true)
        {
            if (once)
            {
                grosRobotGO.SetActive(true);
                grosRobotWithAnim.SetTrigger("Water");
                once = false;
                Destroy(this.gameObject);
            }
        }
    }
}
