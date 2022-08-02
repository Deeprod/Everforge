using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bar : MonoBehaviour
{
    private RectTransform rt;
    private Image[] imageFill;
    private GameObject[] imageDot;
    private Image imageFillContainer;
    private GameObject param;
    
    private int nb;
    private int nbMax;
    private int nbDot;
    private int nbDotMax;

    private float imageFillColorR;
    private float imageFillColorG;
    private float imageFillColorB;
    private float imageFillColorA;
    private bool imageFillColorUp;

    private float blinkSpeed;
    private float blinkMaxAlpha;

    private float percentage;
    private TMP_Text tmpPercentage;

    void Start()
    {
        param = GameObject.Find("Parameters");

        nb = 0;
        nbMax = 5;
        nbDotMax = (int)param.GetComponent<Parameters>().get_maxDotNb();
        blinkSpeed = 0.005f;
        percentage = 0.0f;
        nbDot = 0;
        blinkMaxAlpha = 0.35f;

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

        tmpPercentage = rt.Find("Percentage").GetComponent<TMP_Text>();

        imageDot = new GameObject[nbDotMax];
        for (int i = 0; i < nbDotMax; i++)
        {
            imageDot[i] = rt.Find("Dot" + (i+1).ToString()).gameObject;
            imageDot[i].SetActive(false);
        }
    }

    void Update()
    {
        if(imageFillColorUp)
        {
            imageFillColorA = imageFillColorA + blinkSpeed;
            if(imageFillColorA > blinkMaxAlpha)
            {
                imageFillColorA = blinkMaxAlpha;
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

        if(nbDot > 0 && nb < nbMax)
        {
            percentage += 0.01f * nbDot * nbDot;
            percentage = Mathf.Min(percentage, 100);

            if(percentage == 100)
            {
                tmpPercentage.text = "100%";
                imageFill[nb].color = new Vector4(imageFillColorR, imageFillColorG, imageFillColorB, 1.0f);
                nb += 1;
                percentage = 0;
            }
            else
            {
                imageFill[nb].color = new Vector4(imageFillColorR, imageFillColorG, imageFillColorB, imageFillColorA);
                tmpPercentage.text = (Mathf.Floor(percentage*10)/10).ToString() + "%";
            }
            
        }
    }










    public void addDot()
    {
        nbDot += 1;
        imageDot[nbDot-1].SetActive(true);
    }
    public void removeDot()
    {
        nbDot -= 1;
        imageDot[nbDot].SetActive(false);

        if(nbDot == 0 && nb < nbMax)
        {
            imageFill[nb].color = new Vector4(imageFillColorR, imageFillColorG, imageFillColorB, 0.12f);
        }
    }
}
