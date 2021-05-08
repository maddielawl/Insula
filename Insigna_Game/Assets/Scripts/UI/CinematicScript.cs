using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinematicScript : MonoBehaviour
{
    private GameObject Tutorial;
    public void EndCinematic()
    {
        MenusManager.instance.player.SetActive(true);
        MenusManager.instance.player.GetComponent<PlayerInput>().enabled = true;
        MenusManager.instance.Cinematic.SetActive(false);
        if (Tutorial != null)
        {
            Tutorial = GameObject.Find("Tutorial");
            Tutorial.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}