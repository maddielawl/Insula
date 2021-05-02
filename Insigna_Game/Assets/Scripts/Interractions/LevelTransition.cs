using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private GameObject player;
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
            player.SetActive(false);
            StartCoroutine(LoadLevel2(2));
        }
    }
    
    IEnumerator LoadLevel2(int sceneIndex)
    {
        yield return new WaitForSeconds(0.5f);
        MenusManager.instance.level2loaded = true;
        SceneManager.LoadScene(sceneIndex);
    }
}
