using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFollow : MonoBehaviour
{

    public EnemyFollowN02T02 toila;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        toila.chasePlayer = false;
    }
}
