using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    public BoxCollider2D[] interractablesCollider;
    public bool doFade = false;

    private void Start()
    {
        for (int i = 0; i < interractablesCollider.Length; i++)
        {
            if (interractablesCollider[i] != null)
            {
                bool interractableColliderState = interractablesCollider[i].enabled;
                interractablesCollider[i].enabled = false;
                if (interractablesCollider[i].transform.parent.name == "MadnessInterractions")
                {
                    interractablesCollider[i].enabled = interractableColliderState;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < interractablesCollider.Length; i++)
            {
                if (interractablesCollider[i] != null)
                {
                    bool interractableColliderState = interractablesCollider[i].enabled;
                    interractablesCollider[i].enabled = true;
                    if (interractablesCollider[i].transform.parent.name == "MadnessInterractions")
                    {
                        interractablesCollider[i].enabled = interractableColliderState;
                    }
                }
            }
            if (doFade)
            {
                StartCoroutine(FadeToTransparent(this.gameObject, 1f));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < interractablesCollider.Length; i++)
            {
                if (interractablesCollider[i] != null)
                {
                    interractablesCollider[i].enabled = false;
                }
            }
        }
    }


    public IEnumerator FadeToTransparent(GameObject fog, float fadeSpeedB)
    {
        Color objectColor = transform.GetComponent<SpriteRenderer>().color;
        float fadeAmountB;
        while (transform.GetComponent<SpriteRenderer>().color.a > 0)
        {
            fadeAmountB = objectColor.a - (fadeSpeedB * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmountB);
            transform.GetComponent<SpriteRenderer>().color = objectColor;
            yield return null;
        }
    }
}
