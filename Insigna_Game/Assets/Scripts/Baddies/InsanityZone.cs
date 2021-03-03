using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsanityZone : MonoBehaviour
{
    public GameObject insanityShake;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.isScared = true;
            insanityShake.SetActive(true);
            FindObjectOfType<AudioManager>().Play("InsideMadness");
            StartCoroutine(GameManager.Instance.InsideMadnessZone());
            StopCoroutine(GameManager.Instance.SanityDecrement());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.isScared = false;
            insanityShake.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("InsideMadness");
            StopCoroutine(GameManager.Instance.InsideMadnessZone());
            StartCoroutine(GameManager.Instance.SanityDecrement());
        }
    }
}
