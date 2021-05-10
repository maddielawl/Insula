using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouliedubas : MonoBehaviour
{
    public Interractable parent;
    public GameObject robotquivatomber;
    public GameObject robotavant;

    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
    }

        private void Update()
    {
        if(parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;
            robotavant.SetActive(false);
            robotquivatomber.SetActive(true);
            Destroy(this.transform.parent.gameObject);
        }
    }

}
