using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robotquimeurt : MonoBehaviour
{
    public Interractable parent;
    public GameObject champifragilestarf;
    public GameObject lerobot;
    public Animator a;
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
            champifragilestarf.SetActive(false);
            a.SetTrigger("Trigger");
            lerobot.SetActive(false);
        }
    }
}
