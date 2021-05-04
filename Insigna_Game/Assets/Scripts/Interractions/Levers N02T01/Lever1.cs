using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{

    private ButtonL02 button;
    private Interractable parent;

    private bool order = false;


    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
        button = transform.parent.parent.GetComponent<ButtonL02>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;

            if (button.lever1 == 0)
            {
                if (order == false)
                {
                    button.lever1++;
                }
                if (order == true)
                {
                    button.lever1--;
                }
                Debug.Log(button.lever1);
                return;
            }
            if (button.lever1 == 1)
            {
                if (order == true)
                {
                    button.lever1--;
                    order = false;
                    return;
                }
                if (order == false)
                {
                    button.lever1++;
                    order = true;
                    return;
                }
                Debug.Log(button.lever1);

            }
            if (button.lever1 == 2)
            {
                if (order == false)
                {
                    button.lever1++;
                }
                if (order == true)
                {
                    button.lever1--;
                }
                Debug.Log(button.lever1);
                return;

            }
        }


    }

}

