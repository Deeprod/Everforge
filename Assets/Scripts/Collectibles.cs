using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private GameObject collectibles;
    private GameObject param;
    private float nb;
    private bool isDotFull;
    private bool isDotEmpty;
    private float maxNb;
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
    private GameObject barObject;
    
    void Awake()
    {
        nb = 0;
        collectibles = GameObject.Find("Items");
        param = GameObject.Find("Parameters");
        barObject = GameObject.Find("Bar_" + barName);
        scaleSign = 1;

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
        maxNb = param.GetComponent<Parameters>().get_maxDotNb();
        if(nb > 0)
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
    }

    // Start is called before the first frame update
    void OnMouseOver()
    {
        //On Right or Left click, we check if the dot pool is empty or full
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            isDotFull = collectibles.GetComponent<Items>().isDotFull();
            isDotEmpty = collectibles.GetComponent<Items>().isDotEmpty();
        }

        //We add a new dot only if the dot pool is not full and the collectible pool is not full
        if(Input.GetMouseButtonDown(0) && nb != maxNb && !isDotFull)
        {
            nb = Mathf.Min(maxNb, nb + 1);
            collectibles.GetComponent<Items>().SetDot(transform.position.x, transform.position.y, nb);
            barObject.GetComponent<Bar>().addDot();
        }
        //We remove a new dot only if the dot pool is not empty and the collectible pool is not empty
        //Not that !isDotEmpty should be redundant
        else if(Input.GetMouseButtonDown(1) && nb != 0 && !isDotEmpty)
        {  
            collectibles.GetComponent<Items>().RemoveDot(transform.position.x, transform.position.y, nb);
            nb = Mathf.Max(0, nb - 1);
            barObject.GetComponent<Bar>().removeDot();

            if(nb == 0)
            {
                this.transform.localScale = new Vector3(scaleOriginalX, scaleOriginalY, this.transform.localScale.z);
                this.GetComponent<SpriteRenderer>().color = new Vector4(colorOriginalR, colorOriginalG, colorOriginalB, colorOriginalA);
            }
        }
    }
}
