using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private GameObject param;
    public GameObject[] dots;
    public GameObject[] collectibles;
    private Sprite[] collectibleSprites;
    private bool first;
    private float activeDot;

    void Awake()
    {
        // Fetch the collectibles sprites as per defined in the Parameters script
        param = GameObject.Find("Parameters");
        collectibleSprites = param.GetComponent<Parameters>().get_collectibleSprites();

        //Initialize the number of active dots
        activeDot = 0;

        // Initialize the dots, assigning name to a public array, and deactivate
        GameObject[] _dots = new GameObject[GameObject.Find("DotContainer").transform.childCount];
        dots = _dots;
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i] = GameObject.Find("DotContainer").transform.GetChild(i).gameObject;
            dots[i].SetActive(false);
        }

        // Initialize the collectibles, setting up the sprite as per the parameters
        // If the sprites array is not long enough, we re-use the last sprite.
        GameObject[] _collectibles = new GameObject[GameObject.Find("Collectibles").transform.childCount];
        collectibles = _collectibles;
        for (int i = 0; i < collectibles.Length; i++)
        {
            collectibles[i] = GameObject.Find("Collectibles").transform.GetChild(i).gameObject;
            collectibles[i].GetComponent<SpriteRenderer>().sprite = collectibleSprites[Mathf.Min(i,collectibleSprites.Length-1)];  //
        }
    }

    //Set a new dot attched to a collectible
    public void SetDot(float _x, float _y, float _nb)
    {
        first = true;
        for(int i = 0; i < dots.Length; i++)
        {        
            //We go through all the dots, find one that is not active, and place it
            if(!dots[i].activeInHierarchy && first)
            {
                dots[i].SetActive(true);
                dots[i].transform.position = new Vector3(_x + 2,_y + _nb, 0);
                first = false;
            }
        }

        activeDot += 1;
    }

    public void RemoveDot(float _x, float _y, float _nb)
    {
        for(int i = 0; i < dots.Length; i++)
        {
            //Go through all the active dots, if it matches the location, we deactivate it
            if(dots[i].activeInHierarchy)
            {
                if(dots[i].transform.position == new Vector3(_x + 2,_y + _nb, 0))
                {
                    dots[i].SetActive(false);
                }
            }
        }

        activeDot -= 1;
    }

    //Check if all the dots have been allocated
    public bool isDotFull()
    {
        return activeDot == dots.Length;
    }

    //Check if none of the dots have been allocated
    public bool isDotEmpty()
    {
        return activeDot == 0;
    }
}
