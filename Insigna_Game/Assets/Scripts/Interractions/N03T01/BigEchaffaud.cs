using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEchaffaud : MonoBehaviour
{
    public float speed;

    public Transform waypoint1;
    public Transform waypoint2;

    private Vector2 normalisedw1;
    private Vector2 normalisedw2;

    public bool isMoving = false;

    public bool moveTowards1 = false;
    public bool moveTowards2 = false;

    private void Update()
    {
        if (isMoving == true)
        {

            if (moveTowards1 == true)
            {
                normalisedw1 = new Vector2(waypoint1.position.x, -5.6f);

                transform.position = Vector2.MoveTowards(transform.position, normalisedw1, speed * Time.deltaTime);
                return;
            }
            if (moveTowards2 == true)
            {
                normalisedw2 = new Vector2(waypoint2.position.x, -5.6f);

                transform.position = Vector2.MoveTowards(transform.position, normalisedw2, speed * Time.deltaTime);
                return;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Waypoint 1"))
        {
            if (isMoving == true)
            {

                if (moveTowards1 == true)
                {
                    isMoving = false;
                    moveTowards1 = false;
                }
            }
        }
        if (collision.CompareTag("Waypoint 2"))
        {
            if (isMoving == true)
            {

                if (moveTowards2 == true)
                {
                    isMoving = false;
                    moveTowards2 = false;
                }
            }
        }

    }
}
