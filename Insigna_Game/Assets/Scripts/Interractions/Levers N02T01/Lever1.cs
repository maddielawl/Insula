using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    public string leverSfx = "event:/SFX/Environment Sounds/Lever";
    public ButtonL02 button;
    private Interractable parent;

    private bool order = false;

    public Sprite LeverUp;
    public Sprite LeverMiddle;
    public Sprite LeverDown;

    public SpriteRenderer LevelLeftHighlight;
    public SpriteRenderer LevelMiddleHighlight;
    public SpriteRenderer LevelRightHighlight;
    public GameObject feuxUp;
    public GameObject feuxMiddle;
    public GameObject feuxDown;


    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot(leverSfx);
            GameManager.Instance.globalInterractionSecurity = true;
            parent.interractionSecurity = true;


            if (button.lever1 == 0)
            {
                if (order == false)
                {
                    button.lever1++;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LeverMiddle;
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelMiddleHighlight;
                    parent.spriteHighlight.enabled = true;
                    feuxUp.SetActive(false);
                    feuxMiddle.SetActive(true);
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
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LeverDown;
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelRightHighlight;
                    parent.spriteHighlight.enabled = true;
                    feuxMiddle.SetActive(false);
                    feuxDown.SetActive(true);
                    this.gameObject.SetActive(false);
                    return;
                }
                if (order == true)
                {
                    button.lever1--;
                    order = false;
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LeverUp;
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelLeftHighlight;
                    parent.spriteHighlight.enabled = true;
                    feuxMiddle.SetActive(false);
                    feuxUp.SetActive(true);
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
                    transform.parent.GetComponent<SpriteRenderer>().sprite = LeverMiddle;
                    parent.spriteHighlight.enabled = false;
                    parent.spriteHighlight = LevelMiddleHighlight;
                    parent.spriteHighlight.enabled = true;
                    feuxDown.SetActive(false);
                    feuxMiddle.SetActive(true);
                }
                this.gameObject.SetActive(false);
                return;

            }
        }
    }
}

