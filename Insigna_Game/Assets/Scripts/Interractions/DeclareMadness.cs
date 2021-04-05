using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclareMadness : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.sanityZone = this.gameObject;
        GameManager.Instance.sanityZone.SetActive(false);
    }
}
