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

    [SerializeField] private string barName;
    private GameObject barObject;
    
    void Awake()
    {
        nb = 0;
        collectibles = GameObject.Find("Items");
        param = GameObject.Find("Parameters");
        barObject = GameObject.Find("Bar_" + barName);
    }

    void Update()
    {
        maxNb = param.GetComponent<Parameters>().get_maxDotNb();
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
        }
    }
}
