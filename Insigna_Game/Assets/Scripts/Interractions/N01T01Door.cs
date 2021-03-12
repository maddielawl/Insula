using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N01T01Door : MonoBehaviour
{
    private InterractableWithInventory parent;
    public Transform tpPoint;
    public bool isLeverOn = false;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        parent = transform.parent.GetComponent<InterractableWithInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;
            if(isLeverOn == true)
            {
                player.transform.position = tpPoint.position;
            }

        }

    }
}
