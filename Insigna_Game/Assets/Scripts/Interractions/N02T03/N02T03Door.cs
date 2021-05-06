using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N02T03Door : MonoBehaviour
{
    private Interractable parent;
    public GameObject cleeMolette;
    public SpriteRenderer placardHighlight;

    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            cleeMolette.SetActive(true);
            GameManager.Instance.globalInterractionSecurity = false;
            placardHighlight.enabled = false;
            parent.GetComponent<BoxCollider2D>().enabled = false;
            parent.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
