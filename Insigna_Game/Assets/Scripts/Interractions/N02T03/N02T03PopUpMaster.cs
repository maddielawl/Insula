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

    private N02T03Trinket nombre0;
    private N02T03Trinket nombre1;
    private N02T03Trinket nombre2;
    private N02T03Trinket nombre3;
    private N02T03Trinket nombre4;
    private N02T03Trinket nombre5;

    [Header("Code Secret")]
    public int trinket0;
    public int trinket1;
    public int trinket2;
    public int trinket3;
    public int trinket4;
    public int trinket5;

    public bool boole = false;

    private void Awake()
    {
        nombre0 = code0.GetComponent<N02T03Trinket>();
        nombre1 = code1.GetComponent<N02T03Trinket>();
        nombre2 = code2.GetComponent<N02T03Trinket>();
        nombre3 = code3.GetComponent<N02T03Trinket>();
        nombre4 = code4.GetComponent<N02T03Trinket>();
        nombre5 = code5.GetComponent<N02T03Trinket>();

        if (taille >= 1)
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
        if(nombre0.number == trinket0 && nombre1.number == trinket1 &&
            nombre2.number == trinket2 && nombre3.number == trinket3 &&
            nombre4.number == trinket4 && nombre5.number == trinket5)
        {
            if (boole == true)
            {
                GameObject.Find("Diary Coffre").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Diary Coffre").GetComponent<BoxCollider2D>().enabled = true;
            }
            Invoke("QuitInterraction", 1f);
        }
    }

    public void QuitInterraction()
    {
        transform.parent.GetComponent<QuitPopUp>().QuitInterraction();
        transform.parent.GetComponent<QuitPopUp>().Deactivate();
    }
}
