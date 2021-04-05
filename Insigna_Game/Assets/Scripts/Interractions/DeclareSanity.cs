using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclareSanity : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.sanityZone = this.gameObject;
        GameManager.Instance.sanityZone.SetActive(true);
    }
    
}
