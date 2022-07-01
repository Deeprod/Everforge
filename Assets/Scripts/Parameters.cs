using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    [SerializeField] private float maxDotNbPerCollectible;
    [SerializeField] private string[] collectibleSprite;

    public float get_maxDotNb()
    {
        return maxDotNbPerCollectible;
    }

    public Sprite[] get_collectibleSprites()
    {
        Sprite[] _sprite = new Sprite[collectibleSprite.Length];
        for (int i = 0; i < collectibleSprite.Length; i++)
        {
            _sprite[i] = Resources.Load<Sprite>("Sprites/" + collectibleSprite[i]);
        }
        
        return _sprite;
    }

}
