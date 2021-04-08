  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowN02T02 : MonoBehaviour
{

    public float speed;

    private Transform target;

    private Vector2 normalised;

    public Transform waypoint1;

    private Vector2 normalisedw1;

    public Transform waypoint2;

    private Vector2 normalisedw2;

    public bool chasePlayer = true;

    public bool waypoints = false;

    private Rigidbody2D rb;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (chasePlayer == true)
        {
            normalised = new Vector2(target.position.x, 0);

            transform.position = Vector2.MoveTowards(transform.position, normalised, speed * Time.deltaTime);
            return;
        }

        if(waypoints == false)
        {
            normalisedw2 = new Vector2(waypoint2.position.x, 0);

            transform.position = Vector2.MoveTowards(transform.position, normalisedw2, speed * Time.deltaTime);
            return;
        }
        else
        {
            normalisedw1 = new Vector2(waypoint1.position.x, 0);

            transform.position = Vector2.MoveTowards(transform.position, normalisedw1, speed * Time.deltaTime);

            return;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Waypoint 1"))
        {
            waypoints = false;
        }
        if (collision.CompareTag("Waypoint 2"))
        {
            waypoints = true;
        }
        if (collision.CompareTag("Player"))
        {
            chasePlayer = true;
        }
    }

}
