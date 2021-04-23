using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    public Animator anim;
    public Animator fondu;

    private GameObject charatcer;

    private void Start()
    {
        charatcer = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TutorialDisplay());
    }

    public IEnumerator TutorialDisplay()
    {
        tutorial.SetActive(true);
        charatcer.SetActive(false);

        GameManager.Instance.DeactivateInGameActions();

        yield return new WaitForSeconds(5f);

        charatcer.SetActive(true);
        charatcer.SetActive(true);
        anim.SetTrigger("Away");
        fondu.SetTrigger("Away");
        charatcer.SetActive(true);

        yield return new WaitForSeconds(1f);

        
        GameManager.Instance.ActivateInGameActions();

        yield return new WaitForSeconds(1);

        charatcer.SetActive(true);
        Destroy(this.gameObject);

        yield return 0;
    }
}
