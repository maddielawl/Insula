using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
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
            GameManager.Instance.globalInterractionSecurity = true;
            parent.interractionSecurity = true;

            if (button.lever1 == 0)
            {
                if (order == false)
                {
                    button.lever1++;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelMiddle;
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelMiddleHighlight;
                    parent.spriteHighlight.enabled = true;
                }
                if (order == true)
                {
                    button.lever1--;
                }
                this.gameObject.SetActive(false);
                return;
            }
            if (button.lever1 == 1)
            {
                if (order == false)
                {
                    button.lever1++;
                    order = true;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelRight;
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelRightHighlight;
                    parent.spriteHighlight.enabled = true;
                    this.gameObject.SetActive(false);
                    return;
                }
                if (order == true)
                {
                    button.lever1--;
                    order = false;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LevelLeft;
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelLeftHighlight;
                    parent.spriteHighlight.enabled = true;
                    this.gameObject.SetActive(false);
                    return;
                }

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
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelMiddleHighlight;
                    parent.spriteHighlight.enabled = true;
                }
                this.gameObject.SetActive(false);
                return;

            }
        }


    }

}

