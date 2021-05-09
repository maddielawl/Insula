using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever3 : MonoBehaviour
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

            if (button.lever3 == 0)
            {
                if (order == false)
                {
                    button.lever3++;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelMiddle;
                }
                if (order == true)
                {
                    button.lever3--;
                }
                Debug.Log(button.lever3);
                return;
            }
            if (button.lever3 == 1)
            {
                if (order == false)
                {
                    button.lever3++;
                    order = true;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelRight;
                    return;
                }
                if (order == true)
                {
                    button.lever3--;
                    order = false;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelLeft;
                    return;
                }
                Debug.Log(button.lever3);

            }
            if (button.lever3 == 2)
            {
                if (order == false)
                {
                    button.lever3++;
                }
                if (order == true)
                {
                    button.lever3--;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelMiddle;
                }
                Debug.Log(button.lever3);
                return;

            }
        }


    }
}
