using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valves : MonoBehaviour
{
    public int valveposition;

    [Header("Transforms")]
    public Transform buttontransform1;
    public Transform buttontransform2;
    public Transform buttontransform3;
    public Transform buttontransform4;
    public Transform buttontransform5;
    public Transform buttontransform6;
    public Transform buttontransform7;
    public Transform buttontransform8;
    public Transform buttontransform9;

    public Transform selectortransform;

    public void Position1()
    {
        selectortransform.position = buttontransform9.position;
        valveposition = 1;
    }
    public void Position2()
    {
        selectortransform.position = buttontransform8.position;
        valveposition = 2;
    }
    public void Position3()
    {
        selectortransform.position = buttontransform7.position;
        valveposition = 3;
    }
    public void Position4()
    {
        selectortransform.position = buttontransform6.position;
        valveposition = 4;
    }
    public void Position5()
    {
        selectortransform.position = buttontransform5.position;
        valveposition = 5;
    }
    public void Position6()
    {
        selectortransform.position = buttontransform4.position;
        valveposition = 6;
    }
    public void Position7()
    {
        selectortransform.position = buttontransform3.position;
        valveposition = 7;
    }
    public void Position8()
    {
        selectortransform.position = buttontransform2.position;
        valveposition = 8;
    }
    public void Position9()
    {
        selectortransform.position = buttontransform1.position;
        valveposition = 9;
    }
}
