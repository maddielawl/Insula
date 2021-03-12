using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N01T01Door : MonoBehaviour
{
    private InterractableWithInventory parent;
    public Transform tpPoint;
    public bool isLeverOn = false;

    void Start()
    {
        parent = transform.parent.GetComponent<InterractableWithInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;

        }

    }
}
