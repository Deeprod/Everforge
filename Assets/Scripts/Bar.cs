using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private RectTransform rt;
    private Image[] imageFill;
    private Image imageFillContainer;
    private int nb;
    private int nbMax;

    private float imageFillColorR;
    private float imageFillColorG;
    private float imageFillColorB;
    private float imageFillColorA;
    private bool imageFillColorUp;

    private float blinkSpeed;

    void Start()
    {
        nb = 0;
        nbMax = 5;
        blinkSpeed = 0.005f;
        rt = this.GetComponent<RectTransform>();
        imageFill = new Image[nbMax];

        for (int i = 0; i < nbMax; i++)
        {
            imageFill[i] = rt.Find("Fill" + (i+1).ToString()).GetComponent<Image>();
        }

        imageFillColorR = imageFill[0].color.r;
        imageFillColorG = imageFill[0].color.g;
        imageFillColorB = imageFill[0].color.b;
        imageFillColorA = 1.0f; 
        imageFillColorUp = false;

        for (int i = 0; i < nbMax; i++)
        {
            imageFill[i].color = new Vector4(imageFillColorR, imageFillColorG, imageFillColorB, 0.0f);
        }

    }

    void Update()
    {
        if(imageFillColorUp)
        {
            imageFillColorA = imageFillColorA + blinkSpeed;
            if(imageFillColorA > 1)
            {
                imageFillColorA = 1.0f;
                imageFillColorUp = false;
            }
        }
        else
        {
            imageFillColorA = imageFillColorA - blinkSpeed;
            if(imageFillColorA < 0)
            {
                imageFillColorA = 0.0f;
                imageFillColorUp = true;
            }
        }

        imageFill[nb].color = new Vector4(imageFillColorR, imageFillColorG, imageFillColorB, imageFillColorA);
    }
}
