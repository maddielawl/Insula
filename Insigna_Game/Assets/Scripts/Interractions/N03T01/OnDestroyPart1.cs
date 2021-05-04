using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyPart1 : MonoBehaviour
{

    public GameObject part2;

    private void OnDestroy()
    {
        part2.SetActive(true);
    }

}
