using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N02T03Door : MonoBehaviour
{
    private Interractable parent;
    public GameObject tournevils;

    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            tournevils.SetActive(true);
            GameManager.Instance.globalInterractionSecurity = false;
            Destroy(this.transform.parent.gameObject);
        }

    }
}
