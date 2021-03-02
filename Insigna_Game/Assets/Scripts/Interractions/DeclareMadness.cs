using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclareMadness : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.madnessZone = this.gameObject;
        GameManager.Instance.madnessZone.SetActive(false);
    }
}
