using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto3_Activate : MonoBehaviour
{
    private InterractableN1_T1Door parent;

    private GameObject player;
    public BoxCollider2D tutorial3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        parent = transform.parent.GetComponent<InterractableN1_T1Door>();
        tutorial3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            Debug.Log("bruh");
            parent.interractionSecurity = true;
            tutorial3.enabled = true;
        }
    }
}
