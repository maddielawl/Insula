using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverParticles : MonoBehaviour
{

    public GameObject particles;

    private void OnMouseEnter()
    {
        particles.SetActive(true);
    }
    private void OnMouseExit()
    {
        particles.SetActive(false);
    }
}
