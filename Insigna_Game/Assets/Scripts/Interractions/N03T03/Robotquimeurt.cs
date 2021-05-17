using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robotquimeurt : MonoBehaviour
{
    public Interractable parent;
    public GameObject champifragilestarf;
    public GameObject finduniveau;
    public GameObject fin;
    public Fin fini;

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
            finduniveau.SetActive(true);
            fin.SetActive(true);
            parent.interractionSecurity = true;
            finduniveau.SetActive(true);
            fin.SetActive(true);
            finduniveau.SetActive(true);
            fin.SetActive(true);
            fini.FinDuNiveau();
            champifragilestarf.SetActive(false);
            fin.SetActive(true);
            a.SetTrigger("Trigger");
        }
    }
}
