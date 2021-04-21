using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N03Woder : MonoBehaviour
{

    public Transform respawn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = respawn.position;
    }

}
