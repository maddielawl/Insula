using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CinematicScript : MonoBehaviour
{
    private GameObject Tutorial;
    public void EndCinematic()
    {
        CursorManager.Instance.keepCursor = false;
        CursorManager.Instance.GetComponent<Image>().enabled = true;
        MenusManager.instance.player.SetActive(true);
        MenusManager.instance.player.GetComponent<PlayerInput>().enabled = true;
        MenusManager.instance.Cinematic.SetActive(false);
        if (Tutorial == null)
        {
            Tutorial = GameObject.Find("Tutorial");
            Tutorial.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
