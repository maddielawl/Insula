using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{

    public bool light = false;

    public GameObject lightsOn;
    public GameObject lightsOff;

    public bool isphareoujour;

    public EnvrioManager em;

    public SpriteRenderer switchHighlightSprRend;
    public SpriteRenderer switchSprRend;
    public Sprite[] switchSpr;
    public Sprite[] switchHighlightSpr;

    public GameObject lampGreen;
    public GameObject lampRed;

    public void ActiveLights()
    {
        if (light == false)
        {
            if (em.electricity == true)
            {
                lightsOn.SetActive(true);
                lightsOff.SetActive(false);

                switchSprRend.sprite = switchSpr[1];
                switchHighlightSprRend.enabled = false;
                switchHighlightSprRend.sprite = switchHighlightSpr[1];
                switchHighlightSprRend.enabled = true;

                lampGreen.SetActive(true);
                lampRed.SetActive(false);

                light = true;
                if (isphareoujour == false)
                {
                    em.phareonoroff = true;
                }
                else
                {
                    em.dayornight = false;
                }
            }
        }
        else
        {
            if (em.electricity == true)
            {
                lightsOn.SetActive(false);
                lightsOff.SetActive(true);

                switchSprRend.sprite = switchSpr[0];
                switchHighlightSprRend.enabled = false;
                switchHighlightSprRend.sprite = switchHighlightSpr[0];
                switchHighlightSprRend.enabled = true;

                lampGreen.SetActive(false);
                lampRed.SetActive(true);

                light = false;
                if (isphareoujour == false)
                {
                    em.phareonoroff = false;
                }
                else
                {
                    em.dayornight = true;
                }
            }
        }
    }
}
