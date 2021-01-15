using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PointAndClick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interractable"))
        {
            Interractable component = other.gameObject.GetComponent<Interractable>();

            component.isNear = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interractable"))
        {
            Interractable component = other.gameObject.GetComponent<Interractable>();

            component.isNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interractable"))
        {
            Interractable component = other.gameObject.GetComponent<Interractable>();

            component.isNear = false;
        }
    }
}
