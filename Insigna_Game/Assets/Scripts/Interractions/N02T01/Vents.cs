using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vents : MonoBehaviour
{
    public GameObject inside;
    public GameObject outside;

    public bool isInside = false;

    public Animator playerAnim;
    public PlayerData player;
    public RuntimeAnimatorController characterBasicAC;
    public AnimatorOverrideController characterVentAOC;

    private GameObject[] allBoxColliders;

    private BoxCollider2D[] allBoxCollier2DDisabled = new BoxCollider2D[100];
    private int length = 0;

    private void Start()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }


    public void GetInside(GameObject thenear)
    {
        UIManager.Instance.HelmetIsOff();
        GameManager.Instance.playerInVent = true;
        outside.SetActive(false);
        inside.SetActive(true);
        playerAnim.runtimeAnimatorController = characterVentAOC;
        player.isInVent = true;
        allBoxColliders = GameObject.FindGameObjectsWithTag("Interractable");
        for (int i = 0; i < allBoxColliders.Length; i++)
        {
            if (allBoxColliders[i].GetComponent<BoxCollider2D>() != null)
            {
                if (allBoxColliders[i].GetComponent<BoxCollider2D>().enabled == false)
                {
                    Debug.Log(allBoxColliders[i].name);
                    allBoxCollier2DDisabled[length] = allBoxColliders[i].GetComponent<BoxCollider2D>();
                    length += 1;
                }

                if (allBoxColliders[i].GetComponent<BoxCollider2D>().enabled)
                {
                    allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = false;
                }

                if (allBoxColliders[i].name == "HealthPack 2")
                {
                    allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                }
                if (allBoxColliders[i].name == "Grille (1)")
                {
                    allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                }
                if (allBoxColliders[i].name == "Grille (2)")
                {
                    allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                }
                if (allBoxColliders[i].name == "Grille (3)")
                {
                    allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                }

            }
        }


    }

    public void GetOutside(GameObject thenear)
    {
        GameManager.Instance.playerInVent = false;
        inside.SetActive(false);
        outside.SetActive(true);
        playerAnim.runtimeAnimatorController = characterBasicAC;
        player.isInVent = true;
        for (int i = 0; i < allBoxColliders.Length; i++)
        {
            if (allBoxColliders[i] != null)
            {
                if (allBoxColliders[i].GetComponent<BoxCollider2D>() != null)
                {
                    allBoxColliders[i].GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }

        for (int i = 0; i < allBoxCollier2DDisabled.Length; i++)
        {
            if (allBoxCollier2DDisabled[i] != null)
            {
                if (allBoxColliders[i].GetComponent<BoxCollider2D>() != null)
                {
                    allBoxCollier2DDisabled[i].GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
        length = 0;
    }

}
