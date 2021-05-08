using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercheAppear : MonoBehaviour
{

    public Interractable parent;
    public GameObject perche;

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
            perche.transform.parent = null;

            // perche.transform.GetComponent<Items>().objectSpriteRenderer = perche.transform.GetComponent<SpriteRenderer>();
        }
    }
}
