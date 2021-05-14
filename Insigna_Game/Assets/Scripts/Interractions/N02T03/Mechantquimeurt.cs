using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechantquimeurt : MonoBehaviour
{

    public GameObject robotDcd;
    public GameObject SanityZone;
    public GameObject Robot;

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collider 1"))
        {
            SanityZone.SetActive(false);
            robotDcd.SetActive(true);
            Destroy(this.gameObject);
        }
    }*/

    public void RobotDead()
    {
        SanityZone.SetActive(false);
        Robot.SetActive(false);
        robotDcd.SetActive(true);
        robotDcd.GetComponent<Animator>().SetTrigger("Broken");
    }
}
