using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N02T03PopUpMaster : MonoBehaviour
{
    [Header("Selecteur de Taille")]
    public int taille;

    [Header("Image = true ou Chiffres = false")]
    public bool selector = false;

    [Header("Emplacements de code")]
    public GameObject code0;
    public GameObject code1;
    public GameObject code2;
    public GameObject code3;
    public GameObject code4;
    public GameObject code5;

    private void Awake()
    {
        if(taille >= 1)
        {
            code0.SetActive(true);
        }
        if (taille >= 2)
        {
            code1.SetActive(true);
        }
        if (taille >= 3)
        {
            code2.SetActive(true);
        }
        if (taille >= 4)
        {
            code3.SetActive(true);
        }
        if (taille >= 5)
        {
            code4.SetActive(true);
        }
        if (taille >= 6)
        {
            code5.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
