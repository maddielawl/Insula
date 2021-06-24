using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CinematicScript : MonoBehaviour
{
    private GameObject Tutorial;
    public MenusManager menus;

    public void EndCinematic()
    {
        for (int i = 0; i < MenusManager.instance.allColliderInterractable.Length; i++)
        {
            if (MenusManager.instance.allColliderInterractable[i].name == "BarreauBrake" || MenusManager.instance.allColliderInterractable[i].name == "Lever" || MenusManager.instance.allColliderInterractable[i].name == "Door" || MenusManager.instance.allColliderInterractable[i].name == "ButtonInteract" || MenusManager.instance.allColliderInterractable[i].name == "ButtonInteract (1)" || MenusManager.instance.allColliderInterractable[i].name == "ExitInteract")
            {
                MenusManager.instance.allColliderInterractable[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Level", 1);

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
        menus.AddPauseGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndCinematic();
        }
    }
}
