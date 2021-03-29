using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N01T01Door : MonoBehaviour
{
    private Interractable parent;
    public Transform tpPoint;
    public bool isLeverOn = false;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        parent = transform.parent.GetComponent<Interractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;
            if(isLeverOn == true)
            {
                StartCoroutine(FadeToBlack());
            }

        }

    }

    public IEnumerator FadeToBlack(bool fadeToBlack = true, float fadeSpeed = 1f)
    {
        Color objectColor = UIManager.Instance.blackScreen.GetComponent<Image>().color;
        float fadeAmount;
        if(fadeToBlack)
        {
            while (UIManager.Instance.blackScreen.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                UIManager.Instance.blackScreen.GetComponent<Image>().color = objectColor;
                yield return null;
            }

            player.transform.position = tpPoint.position;
            yield return new WaitForSeconds(2.5f);
            
            while (UIManager.Instance.blackScreen.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = UIManager.Instance.blackScreen.GetComponent<Image>().color.a - (fadeSpeed * Time.deltaTime);
                
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                UIManager.Instance.blackScreen.GetComponent<Image>().color = objectColor;
                yield return null;
            }
            
            fadeToBlack = false;
        }
    }
}
