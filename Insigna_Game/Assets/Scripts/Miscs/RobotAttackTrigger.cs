using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAttackTrigger : MonoBehaviour
{
    public Animator robotAnimator;
    public string splishSplashSfx = "event:/Robots/Splish Splash";
    FMOD.Studio.EventInstance splishSplashEvent;

    private void Awake()
    {
        splishSplashEvent = FMODUnity.RuntimeManager.CreateInstance(splishSplashSfx);
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            splishSplashEvent.start();
            robotAnimator.SetBool("Attack", true);
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            splishSplashEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            robotAnimator.SetBool("Attack", false);
        }
    }

    void Update()
    {
        
    }
}
