using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finduniveau3 : MonoBehaviour
{
    public Interractable parent;
    private GameObject player;
    public int sceneIndex;
    void Start()
    {
        parent = this.GetComponentInParent<Interractable>();
        player = GameObject.FindGameObjectWithTag("Player");
        this.parent.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(parent.interractionSecurity == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player Sounds/Level Transition");
            player.GetComponent<Player>().StateMachine.CurrentState.Exit();
            MenusManager.instance.level2loaded = true;
            SceneManager.LoadScene(sceneIndex);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Level", sceneIndex);
        }
    }
}
