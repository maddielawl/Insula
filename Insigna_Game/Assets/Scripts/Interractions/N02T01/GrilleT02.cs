using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleT02 : MonoBehaviour
{
    private Interractable parent;

    public Vents vents;

    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
    }


    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = false;
            GameManager.Instance.globalInterractionSecurity = false;
            vents.GetOutside(this.gameObject);



        }
    }
}
