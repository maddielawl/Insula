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
    public SpriteRenderer LevelLeftHighlight;
    public SpriteRenderer LevelMiddleHighlight;
    public SpriteRenderer LevelRightHighlight;


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
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelMiddleHighlight;
                    parent.spriteHighlight.enabled = true;
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
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelRightHighlight;
                    parent.spriteHighlight.enabled = true;
                    return;
                }
                if (order == true)
                {
                    button.lever2--;
                    order = false;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelLeft;
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelLeftHighlight;
                    parent.spriteHighlight.enabled = true;
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
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelMiddleHighlight;
                    parent.spriteHighlight.enabled = true;
                }
                return;

            }
        }


    }
}
