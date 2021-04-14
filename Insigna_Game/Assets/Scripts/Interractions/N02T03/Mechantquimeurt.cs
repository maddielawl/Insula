using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechantquimeurt : MonoBehaviour
{

    public GameObject robotDcd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collider 1"))
        {
            robotDcd.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Aaa");
            Destroy(this.gameObject);
        }
    }
}
