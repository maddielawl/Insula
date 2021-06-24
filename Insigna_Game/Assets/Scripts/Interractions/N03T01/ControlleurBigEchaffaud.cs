using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlleurBigEchaffaud : MonoBehaviour
{
    public BigEchaffaud echaffaud;

    public void GoRight()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Platform moving", 1);
        echaffaud.moveTowards2 = true;
        echaffaud.moveTowards1 = false;
        echaffaud.isMoving = true;
    }

    public void GoLeft()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Platform moving", 1);
        echaffaud.moveTowards1 = true;
        echaffaud.moveTowards2 = false;
        echaffaud.isMoving = true;
    }

    public void Stop()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Platform moving", 0);
        echaffaud.isMoving = false;
    }

}
