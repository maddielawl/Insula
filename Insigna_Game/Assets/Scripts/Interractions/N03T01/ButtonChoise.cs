using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChoise : MonoBehaviour
{
    private Interractable parent;

    public int choise;

    public ControlleurBigEchaffaud control;

    public EnvrioManager em;

    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;
            if (em.electricity == true)
            {
                switch (choise)
                {
                    case 0:
                        control.GoLeft();
                        break;
                    case 1:
                        control.Stop();
                        break;
                    case 2:
                        control.GoRight();
                        break;
                }
            }
        }
    }
}
