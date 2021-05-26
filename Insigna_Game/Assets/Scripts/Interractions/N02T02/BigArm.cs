using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigArm : MonoBehaviour
{
    public string armSfx = "event:/SFX/Environment Sounds/Big Arm";
    public FMOD.Studio.EventInstance bigArmEvent;

    public float speed;

    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;
    public Transform waypoint4;

    private Vector2 normalisedw1;
    private Vector2 normalisedw2;
    private Vector2 normalisedw3;
    private Vector2 normalisedw4;

    public bool isMoving = false;

    public bool moveTowards1 = false;
    public bool moveTowards2 = false;
    public bool moveTowards3 = false;
    public bool moveTowards4 = false;

    private void Awake()
    {
        bigArmEvent = FMODUnity.RuntimeManager.CreateInstance(armSfx);
    }
    private void Update()
    {
        if (isMoving == true)
        {
            bigArmEvent.start();
            if (moveTowards1 == true)
            {
                normalisedw1 = new Vector2(waypoint1.position.x, waypoint1.position.y);
                Vector2 transformPos2D = new Vector2(transform.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, normalisedw1, speed * Time.deltaTime);
                if (transformPos2D == normalisedw1)
                {
                    isMoving = false;
                    moveTowards1 = false;
                    bigArmEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }
                //return;
            }
            if (moveTowards2 == true)
            {
                normalisedw2 = new Vector2(waypoint2.position.x, waypoint1.position.y);
                Vector2 transformPos2D = new Vector2(transform.position.x, transform.position.y);

                transform.position = Vector2.MoveTowards(transform.position, normalisedw2, speed * Time.deltaTime);
                if (transformPos2D == normalisedw2)
                {
                    isMoving = false;
                    moveTowards2 = false;
                }
                //return;
            }
            if (moveTowards3 == true)
            {
                normalisedw3 = new Vector2(waypoint3.position.x, waypoint1.position.y);
                Vector2 transformPos2D = new Vector2(transform.position.x, transform.position.y);

                transform.position = Vector2.MoveTowards(transform.position, normalisedw3, speed * Time.deltaTime);
                if (transformPos2D == normalisedw3)
                {
                    isMoving = false;
                    moveTowards3 = false;
                }
                //return;
            }
            if (moveTowards4 == true)
            {
                normalisedw4 = new Vector2(waypoint4.position.x, waypoint1.position.y);
                Vector2 transformPos2D = new Vector2(transform.position.x, transform.position.y);

                transform.position = Vector2.MoveTowards(transform.position, normalisedw4, speed * Time.deltaTime);
                if (transformPos2D == normalisedw4)
                {
                    isMoving = false;
                    moveTowards4 = false;
                }
                //return;
            }

        }
    }
}
