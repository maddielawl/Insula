using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baisetamerevictor : MonoBehaviour
{

    public bool bool1;
    public bool bool2;
    public bool bool3;
    public bool bool4;
    public bool bool5;
    public bool bool6;
    public bool bool7;

    public GameObject lightlit1;
    public GameObject lightlit2;
    public GameObject lightlit3;
    public GameObject lightlit4;
    public GameObject lightlit5;
    public GameObject lightlit6;
    public GameObject lightlit7;

    public GameObject lightunlit1;
    public GameObject lightunlit2;
    public GameObject lightunlit3;
    public GameObject lightunlit4;
    public GameObject lightunlit5;
    public GameObject lightunlit6;
    public GameObject lightunlit7;

    void Update()
    {
        if(bool1 == false && bool2 == false && bool3 == false && bool4 == false && bool5 == false && bool6 == false && bool7 == false)
        {
            Invoke("QuitInterraction", 1f);
        }
    }

    public void bouton1()
    {
        if(bool1 == false)
        {
            bool1 = true;
            lightlit1.SetActive(true);
            lightunlit1.SetActive(false);
            if (bool7 == false)
            {
                bool7 = true;
                lightlit7.SetActive(true);
                lightunlit7.SetActive(false);
                if (bool2 == false)
                {
                    bool2 = true;
                    lightlit2.SetActive(true);
                    lightunlit2.SetActive(false);
                    return;
                }
                else
                {
                    bool2 = false;
                    lightlit2.SetActive(false);
                    lightunlit2.SetActive(true);
                    return;
                }
            }
            else
            {
                bool7 = false;
                lightlit7.SetActive(false);
                lightunlit7.SetActive(true);
                if (bool2 == false)
                {
                    bool2 = true;
                    lightlit2.SetActive(true);
                    lightunlit2.SetActive(false);
                    return;
                }
                else
                {
                    bool2 = false;
                    lightlit2.SetActive(false);
                    lightunlit2.SetActive(true);
                    return;
                }

            }
        }
        else
        {
            bool1 = false;
            lightlit1.SetActive(false);
            lightunlit1.SetActive(true);
            if (bool7 == false)
            {
                bool7 = true;
                lightlit7.SetActive(true);
                lightunlit7.SetActive(false);
                if (bool2 == false)
                {
                    bool2 = true;
                    lightlit2.SetActive(true);
                    lightunlit2.SetActive(false);
                    return;
                }
                else
                {
                    bool2 = false;
                    lightlit2.SetActive(false);
                    lightunlit2.SetActive(true);
                    return;
                }
            }
            else
            {
                bool7 = false;
                lightlit7.SetActive(false);
                lightunlit7.SetActive(true);
                if (bool2 == false)
                {
                    bool2 = true;
                    lightlit2.SetActive(true);
                    lightunlit2.SetActive(false);
                    return;
                }
                else
                {
                    bool2 = false;
                    lightlit2.SetActive(false);
                    lightunlit2.SetActive(true);
                    return;
                }

            }
        }
        
    }
    public void bouton2()
    {
        if(bool2 == false)
        {
            bool2 = true;
            lightlit2.SetActive(true);
            lightunlit2.SetActive(false);
            if (bool1 == false)
            {
                bool1 = true;
                lightlit1.SetActive(true);
                lightunlit1.SetActive(false);
                if (bool3 == false)
                {
                    bool3 = true;
                    lightlit3.SetActive(true);
                    lightunlit3.SetActive(false);
                    return;
                }
                else
                {
                    bool3 = false;
                    lightlit3.SetActive(false);
                    lightunlit3.SetActive(true);
                    return;
                }
            }
            else
            {
                bool1 = false;
                lightlit1.SetActive(false);
                lightunlit1.SetActive(true);
                if (bool3 == false)
                {
                    bool3 = true;
                    lightlit3.SetActive(true);
                    lightunlit3.SetActive(false);
                    return;
                }
                else
                {
                    bool3 = false;
                    lightlit3.SetActive(false);
                    lightunlit3.SetActive(true);
                    return;
                }

            }
        }
        else
        {
            bool2 = false;
            lightlit2.SetActive(false);
            lightunlit2.SetActive(true);
            if (bool1 == false)
            {
                bool1 = true;
                lightlit1.SetActive(true);
                lightunlit1.SetActive(false);
                if (bool3 == false)
                {
                    bool3 = true;
                    lightlit3.SetActive(true);
                    lightunlit3.SetActive(false);
                    return;
                }
                else
                {
                    bool3 = false;
                    lightlit3.SetActive(false);
                    lightunlit3.SetActive(true);
                    return;
                }
            }
            else
            {
                bool1 = false;
                lightlit1.SetActive(false);
                lightunlit1.SetActive(true);
                if (bool3 == false)
                {
                    bool3 = true;
                    lightlit3.SetActive(true);
                    lightunlit3.SetActive(false);
                    return;
                }
                else
                {
                    bool3 = false;
                    lightlit3.SetActive(false);
                    lightunlit3.SetActive(true);
                    return;
                }

            }

        }
    }
    public void bouton3()
    {
        if(bool3 == false)
        {
            bool3 = true;
            lightlit3.SetActive(true);
            lightunlit3.SetActive(false);
            if (bool2 == false)
            {
                bool2 = true;
                lightlit2.SetActive(true);
                lightunlit2.SetActive(false);
                if (bool4 == false)
                {
                    bool4 = true;
                    lightlit4.SetActive(true);
                    lightunlit4.SetActive(false);
                    return;
                }
                else
                {
                    bool4 = false;
                    lightlit4.SetActive(false);
                    lightunlit4.SetActive(true);
                    return;
                }
            }
            else
            {
                bool2 = false;
                lightlit2.SetActive(false);
                lightunlit2.SetActive(true);
                if (bool4 == false)
                {
                    bool4 = true;
                    lightlit4.SetActive(true);
                    lightunlit4.SetActive(false);
                    return;
                }
                else
                {
                    bool4 = false;
                    lightlit4.SetActive(false);
                    lightunlit4.SetActive(true);
                    return;
                }

            }
        }
        else
        {
            bool3 = false;
            lightlit3.SetActive(false);
            lightunlit3.SetActive(true);
            if (bool2 == false)
            {
                bool2 = true;
                lightlit2.SetActive(true);
                lightunlit2.SetActive(false);
                if (bool4 == false)
                {
                    bool4 = true;
                    lightlit4.SetActive(true);
                    lightunlit4.SetActive(false);
                    return;
                }
                else
                {
                    bool4 = false;
                    lightlit4.SetActive(false);
                    lightunlit4.SetActive(true);
                    return;
                }
            }
            else
            {
                bool2 = false;
                lightlit2.SetActive(false);
                lightunlit2.SetActive(true);
                if (bool4 == false)
                {
                    bool4 = true;
                    lightlit4.SetActive(true);
                    lightunlit4.SetActive(false);
                    return;
                }
                else
                {
                    bool4 = false;
                    lightlit4.SetActive(false);
                    lightunlit4.SetActive(true);
                    return;
                }

            }
        }
    }
    public void bouton4()
    {
        if(bool4 == false)
        {
            bool4 = true;
            lightlit4.SetActive(true);
            lightunlit4.SetActive(false);
            if (bool3 == false)
            {
                bool3 = true;
                lightlit3.SetActive(true);
                lightunlit3.SetActive(false);
                if (bool5 == false)
                {
                    bool5 = true;
                    lightlit5.SetActive(true);
                    lightunlit5.SetActive(false);
                    return;
                }
                else
                {
                    bool5 = false;
                    lightlit5.SetActive(false);
                    lightunlit5.SetActive(true);
                    return;
                }
            }
            else
            {
                bool3 = false;
                lightlit3.SetActive(false);
                lightunlit3.SetActive(true);
                if (bool5 == false)
                {
                    bool5 = true;
                    lightlit5.SetActive(true);
                    lightunlit5.SetActive(false);
                    return;
                }
                else
                {
                    bool5 = false;
                    lightlit5.SetActive(false);
                    lightunlit5.SetActive(true);
                    return;
                }

            }
        }
        else
        {
            bool4 = false;
            lightlit4.SetActive(false);
            lightunlit4.SetActive(true);
            if (bool3 == false)
            {
                bool3 = true;
                lightlit3.SetActive(true);
                lightunlit3.SetActive(false);
                if (bool5 == false)
                {
                    bool5 = true;
                    lightlit5.SetActive(true);
                    lightunlit5.SetActive(false);
                    return;
                }
                else
                {
                    bool5 = false;
                    lightlit5.SetActive(false);
                    lightunlit5.SetActive(true);
                    return;
                }
            }
            else
            {
                bool3 = false;
                lightlit3.SetActive(false);
                lightunlit3.SetActive(true);
                if (bool5 == false)
                {
                    bool5 = true;
                    lightlit5.SetActive(true);
                    lightunlit5.SetActive(false);
                    return;
                }
                else
                {
                    bool5 = false;
                    lightlit5.SetActive(false);
                    lightunlit5.SetActive(true);
                    return;
                }

            }
        }
    }
    public void bouton5()
    {
        if(bool5 == false)
        {
            bool5 = true;
            lightlit5.SetActive(true);
            lightunlit5.SetActive(false);
            if (bool4 == false)
            {
                bool4 = true;
                lightlit4.SetActive(true);
                lightunlit4.SetActive(false);
                if (bool6 == false)
                {
                    bool6 = true;
                    lightlit6.SetActive(true);
                    lightunlit6.SetActive(false);
                    return;
                }
                else
                {
                    bool6 = false;
                    lightlit6.SetActive(false);
                    lightunlit6.SetActive(true);
                    return;
                }
            }
            else
            {
                bool4 = false;
                lightlit4.SetActive(false);
                lightunlit4.SetActive(true);
                if (bool6 == false)
                {
                    bool6 = true;
                    lightlit6.SetActive(true);
                    lightunlit6.SetActive(false);
                    return;
                }
                else
                {
                    bool6 = false;
                    lightlit6.SetActive(false);
                    lightunlit6.SetActive(true);
                    return;
                }

            }
        }
        else
        {
            bool5 = true;
            lightlit5.SetActive(false);
            lightunlit5.SetActive(true);
            if (bool4 == false)
            {
                bool4 = true;
                lightlit4.SetActive(true);
                lightunlit4.SetActive(false);
                if (bool6 == false)
                {
                    bool6 = true;
                    lightlit6.SetActive(true);
                    lightunlit6.SetActive(false);
                    return;
                }
                else
                {
                    bool6 = false;
                    lightlit6.SetActive(false);
                    lightunlit6.SetActive(true);
                    return;
                }
            }
            else
            {
                bool4 = false;
                lightlit4.SetActive(false);
                lightunlit4.SetActive(true);
                if (bool6 == false)
                {
                    bool6 = true;
                    lightlit6.SetActive(true);
                    lightunlit6.SetActive(false);
                    return;
                }
                else
                {
                    bool6 = false;
                    lightlit6.SetActive(false);
                    lightunlit6.SetActive(true);
                    return;
                }

            }
        }
    }
    public void bouton6()
    {
        if(bool6 == false)
        {
            bool6 = true;
            lightlit6.SetActive(true);
            lightunlit6.SetActive(false);
            if (bool5 == false)
            {
                bool5 = true;
                lightlit5.SetActive(true);
                lightunlit5.SetActive(false);
                if (bool7 == false)
                {
                    bool7 = true;
                    lightlit7.SetActive(true);
                    lightunlit7.SetActive(false);
                    return;
                }
                else
                {
                    bool7 = false;
                    lightlit7.SetActive(false);
                    lightunlit7.SetActive(true);
                    return;
                }
            }
            else
            {
                bool5 = false;
                lightlit5.SetActive(false);
                lightunlit5.SetActive(true);
                if (bool7 == false)
                {
                    bool7 = true;
                    lightlit7.SetActive(true);
                    lightunlit7.SetActive(false);
                    return;
                }
                else
                {
                    bool7 = false;
                    lightlit7.SetActive(false);
                    lightunlit7.SetActive(true);
                    return;
                }

            }
        }
        else
        {
            bool6 = false;
            lightlit6.SetActive(false);
            lightunlit6.SetActive(true);
            if (bool5 == false)
            {
                bool5 = true;
                lightlit5.SetActive(true);
                lightunlit5.SetActive(false);
                if (bool7 == false)
                {
                    bool7 = true;
                    lightlit7.SetActive(true);
                    lightunlit7.SetActive(false);
                    return;
                }
                else
                {
                    bool7 = false;
                    lightlit7.SetActive(false);
                    lightunlit7.SetActive(true);
                    return;
                }
            }
            else
            {
                bool5 = false;
                lightlit5.SetActive(false);
                lightunlit5.SetActive(true);
                if (bool7 == false)
                {
                    bool7 = true;
                    lightlit7.SetActive(true);
                    lightunlit7.SetActive(false);
                    return;
                }
                else
                {
                    bool7 = false;
                    lightlit7.SetActive(false);
                    lightunlit7.SetActive(true);
                    return;
                }

            }
        }
    }
    public void bouton7()
    {
        if(bool7 == false)
        {
            bool7 = true;
            lightunlit7.SetActive(true);
            lightunlit7.SetActive(false);
            if (bool6 == false)
            {
                bool6 = true;
                lightlit6.SetActive(true);
                lightunlit6.SetActive(false);
                if (bool1 == false)
                {
                    bool1 = true;
                    lightlit1.SetActive(true);
                    lightunlit1.SetActive(false);
                    return;
                }
                else
                {
                    bool1 = false;
                    lightlit1.SetActive(false);
                    lightunlit1.SetActive(true);
                    return;
                }
            }
            else
            {
                bool6 = false;
                lightlit6.SetActive(false);
                lightunlit6.SetActive(true);
                if (bool1 == false)
                {
                    bool1 = true;
                    lightlit1.SetActive(true);
                    lightunlit1.SetActive(false);
                    return;
                }
                else
                {
                    bool1 = false;
                    lightlit1.SetActive(false);
                    lightunlit1.SetActive(true);
                    return;
                }

            }
        }
        else
        {
            bool7 = false;
            lightlit7.SetActive(false);
            lightunlit7.SetActive(true);
            if (bool6 == false)
            {
                bool6 = true;
                lightlit6.SetActive(true);
                lightunlit6.SetActive(false);
                if (bool1 == false)
                {
                    bool1 = true;
                    lightlit1.SetActive(true);
                    lightunlit1.SetActive(false);
                    return;
                }
                else
                {
                    bool1 = false;
                    lightlit1.SetActive(false);
                    lightunlit1.SetActive(true);
                    return;
                }
            }
            else
            {
                bool6 = false;
                lightlit6.SetActive(false);
                lightunlit6.SetActive(true);
                if (bool1 == false)
                {
                    bool1 = true;
                    lightlit1.SetActive(true);
                    lightunlit1.SetActive(false);
                    return;
                }
                else
                {
                    bool1 = false;
                    lightlit1.SetActive(false);
                    lightunlit1.SetActive(true);
                    return;
                }

            }
        }
    }

    public void QuitInterraction()
    {
        transform.parent.GetComponent<QuitPopUp>().QuitInterraction();
        Destroy(GameObject.Find(transform.parent.GetComponent<QuitPopUp>().popUpName));
    }

}
