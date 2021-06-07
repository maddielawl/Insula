using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyCompteur : MonoBehaviour
{
    public GameObject codeinterraction;
    public EnvrioManager em;

    public GameObject[] lampOff;
    public GameObject[] lampRed;

    private void OnDestroy()
    {
        codeinterraction.SetActive(true);
        em.electricity = true;
        lampOff[0].SetActive(false);
        lampOff[1].SetActive(false);
        lampRed[0].SetActive(true);
        lampRed[1].SetActive(true);
    }
}
