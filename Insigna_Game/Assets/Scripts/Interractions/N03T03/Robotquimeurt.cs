using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robotquimeurt : MonoBehaviour
{
    public Interractable parent;
    public GameObject champifragilestarf;
    public GameObject finduniveau;
    void Start()
    {
        parent = this.parent.GetComponent<Interractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;
            finduniveau.SetActive(true);
            champifragilestarf.SetActive(false);
        }
    }
}