using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
    public string leverSfx = "event:/SFX/Environment Sounds/Lever";
    public ButtonL02 button;
    private Interractable parent;

    private bool order = false;

    public Sprite LevelLeft;
    public Sprite LevelMiddle;
    public Sprite LevelRight;
    public SpriteRenderer LevelLeftHighlight;
    public SpriteRenderer LevelMiddleHighlight;
    public SpriteRenderer LevelRightHighlight;

    public GameObject isgood;


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

            if (button.lever1 == 2 && button.lever2 == 1 && button.lever3 == 0 && button.lever4 == 2)
            {
                UIManager.Instance.DisplayPortrait(0);
                isgood.SetActive(true);
                Invoke("HideIsGood", 5f);
                return;
            }

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
                this.gameObject.SetActive(false);
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
                    this.gameObject.SetActive(false);
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
                    this.gameObject.SetActive(false);
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
                this.gameObject.SetActive(false);
                return;

            }
        }


    }
    public void HideIsGood()
    {
        UIManager.Instance.HidePortraits();
    }
}
