using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
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

            if (button.lever2 == 0)
            {
                transform.parent.GetComponent<SpriteRenderer>().sprite = LevelLeft;
                if (order == false)
                {
                    button.lever2++;
                }
                if (order == true)
                {
                    button.lever2--;
                }
                Debug.Log(button.lever2);
                return;
            }
            if (button.lever2 == 1)
            {
                transform.parent.GetComponent<SpriteRenderer>().sprite = LevelMiddle;
                if (order == true)
                {
                    button.lever2--;
                    order = false;
                    return;
                }
                if (order == false)
                {
                    button.lever2++;
                    order = true;
                    return;
                }
                Debug.Log(button.lever2);

            }
            if (button.lever2 == 2)
            {
                transform.parent.GetComponent<SpriteRenderer>().sprite = LevelRight;
                if (order == false)
                {
                    button.lever2++;
                }
                if (order == true)
                {
                    button.lever2--;
                }
                Debug.Log(button.lever2);
                return;

            }
        }


    }
}
