using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleT01 : MonoBehaviour
{
    private InterractableVents parent;

    public Vents vents;

    void Start()
    {
        parent = transform.parent.GetComponent<InterractableVents>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            if (vents.isInside == false)
            {
                parent.interractionSecurity = false;
                GameManager.Instance.globalInterractionSecurity = false;
                vents.GetInside(this.gameObject);
                vents.isInside = true;
                this.gameObject.SetActive(false);
                return;
            }
            if(vents.isInside == true)
            {
                parent.interractionSecurity = false;
                GameManager.Instance.globalInterractionSecurity = false;
                vents.GetOutside(this.gameObject);
                vents.isInside = false;
                this.gameObject.SetActive(false);
                return;
            }
        }
    }
}
