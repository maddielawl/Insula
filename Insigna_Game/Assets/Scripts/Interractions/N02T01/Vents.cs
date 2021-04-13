using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vents : MonoBehaviour
{
    public GameObject inside;
    public GameObject outside;
    public GameObject[] nears;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void GetInside() 
    {
        for (int i = 0; i == 6; i++)
        {
            nears[i].SetActive(false);
        }
        inside.SetActive(true);
        outside.SetActive(false);
    }

    public void GetOutside()
    {
        for(int i = 0; i == 6; i++)
        {
            nears[i].SetActive(false);
        }
        inside.SetActive(false);
        outside.SetActive(true);
    }

}
