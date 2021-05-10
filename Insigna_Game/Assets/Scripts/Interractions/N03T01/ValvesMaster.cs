using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValvesMaster : MonoBehaviour
{
    public Valves valves1;
    public Valves valves2;
    public Valves valves3;
    public Valves valves4;

    private void Update()
    {
        if(valves1.valveposition == 1 && valves2.valveposition == 7 && valves3.valveposition == 8 && valves4.valveposition == 4)
        {
            transform.parent.GetComponent<QuitPopUp>().QuitInterraction();
            Destroy(GameObject.Find(transform.parent.GetComponent<QuitPopUp>().popUpName));
        }
    }
}
