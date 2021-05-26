using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformFollowPlatform : MonoBehaviour
{

    public Transform originalplatform;

    void Update()
    {
        transform.position = originalplatform.position;
    }
}
