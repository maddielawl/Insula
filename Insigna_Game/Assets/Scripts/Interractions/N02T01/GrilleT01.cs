using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleT01 : MonoBehaviour
{
    private Interractable parent;

    public Vents vents;

    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = false;
            GameManager.Instance.globalInterractionSecurity = false;
            vents.GetInside(this.gameObject);

        }
    }
}
