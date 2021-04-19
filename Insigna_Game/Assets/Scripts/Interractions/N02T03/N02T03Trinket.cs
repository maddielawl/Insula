using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N02T03Trinket : MonoBehaviour
{

    private N02T03PopUpMaster parent;
    private Text textButton;
    private Image imageButton;

    private int number;

    [Header("Max Number")]
    public int maxNumber;

    public Sprite image0;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;
    public Sprite image6;
    public Sprite image7;
    public Sprite image8;
    public Sprite image9;

    private void Awake()
    {
        parent = transform.parent.GetComponent<N02T03PopUpMaster>();
        textButton = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        imageButton = transform.GetChild(0).GetComponent<Image>();
        if(parent.selector == false)
        {
            number = 0;
            textButton.text = number.ToString();
        }
        if (parent.selector == true)
        {
            number = 0;
            imageButton.sprite = image0;
        }
    }

    public void UpButton()
    {

        if (number == maxNumber)
        {
            number = 0;
            if (parent.selector == true)
            {
                if (number == 0)
                {
                    imageButton.sprite = image0;
                }
                if (number == 1)
                {
                    imageButton.sprite = image1;
                }
                if (number == 2)
                {
                    imageButton.sprite = image2;
                }
                if (number == 3)
                {
                    imageButton.sprite = image3;
                }
                if (number == 4)
                {
                    imageButton.sprite = image4;
                }
                if (number == 5)
                {
                    imageButton.sprite = image5;
                }
                if (number == 6)
                {
                    imageButton.sprite = image6;
                }
                if (number == 7)
                {
                    imageButton.sprite = image7;
                }
                if (number == 8)
                {
                    imageButton.sprite = image8;
                }
                if (number == 9)
                {
                    imageButton.sprite = image9;
                }
            }
            if (parent.selector == false)
            {
                textButton.text = number.ToString();
            }
            return;
        }
        else
        {
            number++;
            if (parent.selector == true)
            {
                if (number == 0)
                {
                    imageButton.sprite = image0;
                }
                if (number == 1)
                {
                    imageButton.sprite = image1;
                }
                if (number == 2)
                {
                    imageButton.sprite = image2;
                }
                if (number == 3)
                {
                    imageButton.sprite = image3;
                }
                if (number == 4)
                {
                    imageButton.sprite = image4;
                }
                if (number == 5)
                {
                    imageButton.sprite = image5;
                }
                if (number == 6)
                {
                    imageButton.sprite = image6;
                }
                if (number == 7)
                {
                    imageButton.sprite = image7;
                }
                if (number == 8)
                {
                    imageButton.sprite = image8;
                }
                if (number == 9)
                {
                    imageButton.sprite = image9;
                }
                
                
            }
            if (parent.selector == false)
            {
                textButton.text = number.ToString();
            }
            return;
        }
        

    }

    public void DownButton()
    {
            if (number == 0)
            {
                number = maxNumber;
                if (parent.selector == true)
                {
                    if (number == 0)
                    {
                        imageButton.sprite = image0;
                    }
                    if (number == 1)
                    {
                        imageButton.sprite = image1;
                    }
                    if (number == 2)
                    {
                        imageButton.sprite = image2;
                    }
                    if (number == 3)
                    {
                        imageButton.sprite = image3;
                    }
                    if (number == 4)
                    {
                        imageButton.sprite = image4;
                    }
                    if (number == 5)
                    {
                        imageButton.sprite = image5;
                    }
                    if (number == 6)
                    {
                        imageButton.sprite = image6;
                    }
                    if (number == 7)
                    {
                        imageButton.sprite = image7;
                    }
                    if (number == 8)
                    {
                        imageButton.sprite = image8;
                    }
                    if (number == 9)
                    {
                        imageButton.sprite = image9;
                    }
                }
                if (parent.selector == false)
                {
                    textButton.text = number.ToString();
                }
                return;
            }
            else
            {
                number--;
                if (parent.selector == true)
                {
                    if (number == 0)
                    {
                        imageButton.sprite = image0;
                    }
                    if (number == 1)
                    {
                        imageButton.sprite = image1;
                    }
                    if (number == 2)
                    {
                        imageButton.sprite = image2;
                    }
                    if (number == 3)
                    {
                        imageButton.sprite = image3;
                    }
                    if (number == 4)
                    {
                        imageButton.sprite = image4;
                    }
                    if (number == 5)
                    {
                        imageButton.sprite = image5;
                    }
                    if (number == 6)
                    {
                        imageButton.sprite = image6;
                    }
                    if (number == 7)
                    {
                        imageButton.sprite = image7;
                    }
                    if (number == 8)
                    {
                        imageButton.sprite = image8;
                    }
                    if (number == 9)
                    {
                        imageButton.sprite = image9;
                    }


                }
                if (parent.selector == false)
                {
                    textButton.text = number.ToString();
                }
                return;
            }

        }
    }

