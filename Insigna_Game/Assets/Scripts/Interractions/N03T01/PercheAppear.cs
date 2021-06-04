using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PercheAppear : MonoBehaviour
{

    public Interractable parent;
    public GameObject perche;
    public bool percheonce = false;
    public EnvrioManager em;
    public TextMeshProUGUI interractiontext;

    public string PercheText;
    public string CodeText;
    public string BaseText;

    void Start()
    {
        parent = transform.parent.gameObject.GetComponent<Interractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;
            if (percheonce == false)
            {
                perche.transform.parent = null;
                percheonce = true;
                interractiontext.text = PercheText;
                UIManager.Instance.DisplayPortrait(1);
                Invoke("HideIsGood", 5f);
                return;
            }
            if(em.woderoff == true)
            {
                interractiontext.text = CodeText;
                UIManager.Instance.DisplayPortrait(1);
                Invoke("HideIsGood", 5f);
            }
            else
            {
                interractiontext.text = BaseText;
                UIManager.Instance.DisplayPortrait(1);
                Invoke("HideIsGood", 5f);
            }

            // perche.transform.GetComponent<Items>().objectSpriteRenderer = perche.transform.GetComponent<SpriteRenderer>();
        }
    }

    public void HideIsGood()
    {
        UIManager.Instance.HidePortraits();
    }

}
