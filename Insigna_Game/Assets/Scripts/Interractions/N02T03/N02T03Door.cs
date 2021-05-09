using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N02T03Door : MonoBehaviour
{
    private Interractable parent;
    public GameObject cleeMolette;
    public GameObject IronChest;
    public SpriteRenderer placardHighlight;
    public SpriteRenderer placardOuvert;

    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
        placardOuvert.enabled = false;
        cleeMolette.SetActive(false);
        IronChest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            cleeMolette.SetActive(true);
            IronChest.SetActive(true);
            GameManager.Instance.globalInterractionSecurity = false;
            placardHighlight.enabled = false;
            placardOuvert.enabled = true;
            parent.GetComponent<BoxCollider2D>().enabled = false;
            parent.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
