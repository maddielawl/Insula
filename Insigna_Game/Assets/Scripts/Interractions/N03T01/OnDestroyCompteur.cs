using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyCompteur : MonoBehaviour
{
    public GameObject codeinterraction;
    public EnvrioManager em;

    private void OnDestroy()
    {
        codeinterraction.SetActive(true);
        em.electricity = true;
    }
}
