using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAttackTrigger : MonoBehaviour
{
    public Animator robotAnimator;
     
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            robotAnimator.SetBool("Attack", true);
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            robotAnimator.SetBool("Attack", false);
        }
    }
}
