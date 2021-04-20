using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N01T01Door : MonoBehaviour
{
    private Interractable parent;
    public Transform tpPoint;
    public bool isLeverOn = false;

    private GameObject player;
    private bool fadeDone;

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
            if (isLeverOn == true)
            {
                StartCoroutine(UIManager.Instance.FadeToBlackTP(player, tpPoint, false));

            }
        }
    }
}
