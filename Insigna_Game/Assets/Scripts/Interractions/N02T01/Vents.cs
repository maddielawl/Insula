using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vents : MonoBehaviour
{
    public GameObject inside;
    public GameObject outside;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void GetInside(Transform insidePos) 
    {
        inside.SetActive(true);
        outside.SetActive(false);
        player = insidePos;
    }

    public void GetOutside(Transform outsidePos)
    {
        inside.SetActive(false);
        outside.SetActive(true);
        player = outsidePos;
    }

}
