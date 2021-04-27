using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicScript : MonoBehaviour
{
    private GameObject Tutorial;
    public void EndCinematic()
    {
        MenusManager.instance.player.SetActive(true);
        MenusManager.instance.Cinematic.SetActive(false);
        Tutorial = GameObject.Find("Tutorial");
        Tutorial.GetComponent<BoxCollider2D>().enabled = true;
    }
}
