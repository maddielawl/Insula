using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever4 : MonoBehaviour
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

            if (button.lever4 == 0)
            {
                if (order == false)
                {
                    button.lever4++;
                }
                if (order == true)
                {
                    button.lever4--;
                }
                Debug.Log(button.lever4);
                return;
            }
            if (button.lever4 == 1)
            {
                if (order == true)
                {
                    button.lever4--;
                    order = false;
                    return;
                }
                if (order == false)
                {
                    button.lever4++;
                    order = true;
                    return;
                }
                Debug.Log(button.lever4);

            }
            if (button.lever4 == 2)
            {
                if (order == false)
                {
                    button.lever4++;
                }
                if (order == true)
                {
                    button.lever4--;
                }
                Debug.Log(button.lever4);
                return;

            }
        }


    }
}
