using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoors : MonoBehaviour
{
    private Interractable parent;
    public Transform tpPoint;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        parent = transform.parent.GetComponent<Interractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;
            StartCoroutine(UIManager.Instance.FadeToBlackTP(player, tpPoint));

        }

    }
}
