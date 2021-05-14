using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
    public ButtonL02 button;
    private Interractable parent;

    private bool order = false;

    public Sprite LevelLeft;
    public Sprite LevelMiddle;
    public Sprite LevelRight;


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

            if (button.lever2 == 0)
            {
                if (order == false)
                {
                    button.lever2++;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelMiddle;
                }
                if (order == true)
                {
                    button.lever2--;
                }
                return;
            }
            if (button.lever2 == 1)
            {
                if (order == false)
                {
                    button.lever2++;
                    order = true;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelRight;
                    return;
                }
                if (order == true)
                {
                    button.lever2--;
                    order = false;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelLeft;
                    return;
                }

            }
            if (button.lever2 == 2)
            {
                if (order == false)
                {
                    button.lever2++;
                }
                if (order == true)
                {
                    button.lever2--;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelMiddle;
                }
                return;

            }
        }


    }
}
