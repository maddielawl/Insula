using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    public Animator anim;

    private GameObject character;

    public BoxCollider2D[] interractablesCollider;

    public float timeBeforeMoving = 1f;
    public GameObject nextTutorial;
    public GameObject postProcess;

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        if (nextTutorial != null)
        {
            nextTutorial.SetActive(false);
        }
        if (postProcess != null)
        {
            postProcess.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MenusManager.instance.inTuto = true;
        character.GetComponent<PlayerInput>().enabled = false;
        transform.GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < interractablesCollider.Length; i++)
        {
            interractablesCollider[i].enabled = false;
        }
        tutorial.SetActive(true);
        if (postProcess != null)
        {
            postProcess.SetActive(true);
        }
        anim.SetTrigger("Up");
    }
    public void SkipTuto()
    {
        for (int i = 0; i < interractablesCollider.Length; i++)
        {
            interractablesCollider[i].enabled = true;
        }

        if (nextTutorial != null)
        {
            nextTutorial.SetActive(true);
        }

        CursorManager.Instance.enabled = true;
        anim.SetTrigger("Down");
        Invoke("WaitBeforeMoving", timeBeforeMoving);
        Destroy(this.gameObject, 1.2f);
    }

    public void WaitBeforeMoving()
    {
        character.GetComponent<PlayerInput>().enabled = true;
        MenusManager.instance.inTuto = false;
    }
}
