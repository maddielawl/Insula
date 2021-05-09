using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadnessAppear : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> arrayobjects = new List<GameObject>();
    [HideInInspector]
    public List<SpriteRenderer> arraysprites = new List<SpriteRenderer>();
    [HideInInspector]
    public Transform arrayparent;

    public string enterMadSfx = "event:/Music/Level 1/Enter corrupt";
    public string exitMadSfx = "event:/Music/Level 1/Exit corrupt";


    private void Start()
    {


        arrayparent = GameObject.FindGameObjectWithTag("Indicible").GetComponent<Transform>();
        GameManager.Instance.indicible = this.gameObject.GetComponent<MadnessAppear>();

        for (int i = 0; i < arrayparent.childCount; i++)
        {
            arrayobjects.Add(arrayparent.GetChild(i).gameObject);
            arraysprites.Add(arrayparent.GetChild(i).GetComponent<SpriteRenderer>());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetAppear();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetDisAppear();
        }
    }

    public void SetAppear()
    {
        FMODUnity.RuntimeManager.PlayOneShot(enterMadSfx);

        for (int i = 0; i < arrayparent.childCount; i++)
        {
            LeanTween.value(arrayobjects[i], SetSpriteAlpha, 0f, 1f,1f);
        }
        
    }
    public void SetDisAppear()
    {
        FMODUnity.RuntimeManager.PlayOneShot(exitMadSfx);

        for (int i = 0; i < arrayparent.childCount; i++)
        {
            LeanTween.value(arrayobjects[i], SetSpriteAlpha, 1f, 0f, 1f);
        }

    }

    public void SetSpriteAlpha(float val)
    {
        for (int i = 0; i < arrayparent.childCount; i++)
        {
            arraysprites[i].color = new Color(1f, 1f, 1f, val);
        }
    }

}
