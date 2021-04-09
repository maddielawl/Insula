using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBigArm : MonoBehaviour
{
    public BigArm arm;

    public int positionSouhaitee = 1;

    private Interractable parent;

    private bool order = false;


    void Start()
    {
        parent = transform.parent.GetComponent<Interractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.interractionSecurity == false)
        {
            parent.interractionSecurity = true;

            switch (positionSouhaitee)
            {
                case 1:
                    arm.isMoving = true;
                    arm.moveTowards1 = true;
                    break;
                case 2:
                    arm.isMoving = true;
                    arm.moveTowards2 = true;
                    break;
                case 3:
                    arm.isMoving = true;
                    arm.moveTowards3 = true;
                    break;
                case 4:
                    arm.isMoving = true;
                    arm.moveTowards4 = true;
                    break;
            }

        }
    }
}
