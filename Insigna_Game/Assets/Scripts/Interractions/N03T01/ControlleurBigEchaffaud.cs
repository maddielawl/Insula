using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlleurBigEchaffaud : MonoBehaviour
{
    public BigEchaffaud echaffaud;

    public void GoRight()
    {
        echaffaud.moveTowards2 = true;
        echaffaud.moveTowards1 = false;
        echaffaud.isMoving = true;
    }

    public void GoLeft()
    {
        echaffaud.moveTowards1 = true;
        echaffaud.moveTowards2 = false;
        echaffaud.isMoving = true;
    }

    public void Stop()
    {
        echaffaud.isMoving = false;
    }

}
