using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{

    private ButtonL02 button;
    private Interractable parent;

    private bool order = false;

    public Sprite LevelLeft;
    public Sprite LevelMiddle;
    public Sprite LevelRight;


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
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelMiddle;
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
                if (order == false)
                {
                    button.lever1++;
                    order = true;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelRight;
                    return;
                }
                if (order == true)
                {
                    button.lever1--;
                    order = false;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelLeft;
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
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelMiddle;
                }
                Debug.Log(button.lever1);
                return;

            }
        }


    }

}

