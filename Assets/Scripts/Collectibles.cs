using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private GameObject collectibles;
    private GameObject param;
    private GameObject barObject;

    private float scaleUpdate;
    private float alphaUpdate;
    private float scaleSign;
    private float scaleOriginalX;
    private float scaleOriginalY;
    private float colorOriginalR;
    private float colorOriginalG;
    private float colorOriginalB;
    private float colorOriginalA;

    [SerializeField] private float scaleUpdateMax;
    [SerializeField] private float scaleUpdateMin;
    [SerializeField] private float scaleFactor;
    [SerializeField] private float alphaFactor;
    [SerializeField] private string barName;

    private bool readyToCollect;
    private bool isFull;

    
    
    void Awake()
    {
        collectibles = GameObject.Find("Items");
        param = GameObject.Find("Parameters");
        barObject = GameObject.Find("Bar_" + barName);
        scaleSign = 1;
        readyToCollect = false;
        isFull = false;

        scaleUpdate = this.transform.localScale.x;
        scaleOriginalX = this.transform.localScale.x;
        scaleOriginalY = this.transform.localScale.y;

        colorOriginalR = this.GetComponent<SpriteRenderer>().color.r;
        colorOriginalG = this.GetComponent<SpriteRenderer>().color.g;
        colorOriginalB = this.GetComponent<SpriteRenderer>().color.b;
        colorOriginalA = 0.5f;
        alphaUpdate = colorOriginalA;
        this.GetComponent<SpriteRenderer>().color = new Vector4(colorOriginalR, colorOriginalG, colorOriginalB, alphaUpdate);
    }



    void Update()
    {
        if(!readyToCollect && !isFull)
        {
            scaleUpdate = scaleUpdate + scaleSign * scaleFactor;
            alphaUpdate = alphaUpdate + scaleSign * alphaFactor;
            if(scaleUpdate > scaleUpdateMax)
            {
                scaleUpdate = scaleUpdateMax;
                scaleSign = -scaleSign;
            }
            else if(scaleUpdate < scaleUpdateMin)
            {
                scaleUpdate = scaleUpdateMin;
                scaleSign = -scaleSign;
            }
            
            this.transform.localScale = new Vector3(scaleUpdate, scaleUpdate, this.transform.localScale.z);
            this.GetComponent<SpriteRenderer>().color = new Vector4(colorOriginalR, colorOriginalG, colorOriginalB, alphaUpdate);
        }
        else if(readyToCollect && !isFull)
        {
            this.GetComponent<SpriteRenderer>().color = new Vector4(colorOriginalR, colorOriginalG, colorOriginalB, 1.0f);
            this.transform.localScale = new Vector3(scaleOriginalX, scaleOriginalY, this.transform.localScale.z);
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && readyToCollect && !isFull)
        {
            readyToCollect = false;
            GameObject.Find("Bar_" + barName).GetComponent<Bar>().addNb();
        }
    }







    public void setReadyToCollect()
    {
        readyToCollect = true;
    }
    public void setIsFull()
    {
        isFull = true;
    }
    public void setIsNotFull()
    {
        isFull = false;
    }
    public void setDisabled()
    {
        gameObject.SetActive(false);
    }
}
