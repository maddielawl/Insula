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

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        character.GetComponent<PlayerInput>().enabled = false;
        transform.GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < interractablesCollider.Length; i++)
        {
            interractablesCollider[i].enabled = false;
        }
        tutorial.SetActive(true);
        anim.SetTrigger("Up");
    }
    public void SkipTuto()
    {
        for (int i = 0; i < interractablesCollider.Length; i++)
        {
            interractablesCollider[i].enabled = true;
        }
        CursorManager.Instance.enabled = true;
        anim.SetTrigger("Down");
        Invoke("WaitBeforeMoving", timeBeforeMoving);
        Destroy(this.gameObject, 1.2f);
    }

    public void WaitBeforeMoving()
    {
        character.GetComponent<PlayerInput>().enabled = true;
    }
}
