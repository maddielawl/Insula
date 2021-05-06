using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechantquimeurt : MonoBehaviour
{

    public GameObject robotDcd;
    public GameObject SanityZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collider 1"))
        {
            SanityZone.SetActive(false);
            robotDcd.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
