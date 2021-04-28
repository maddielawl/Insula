using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private GameObject player;
    public int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Player>().StateMachine.ChangeState(player.GetComponent<Player>().IdleState);
            SceneManager.LoadScene(sceneIndex);
            MenusManager.instance.level2loaded = true;
        }
    }
}
