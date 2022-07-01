using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    [SerializeField] private float maxDotNbPerCollectible;

    public float get_maxDotNb()
    {
        return maxDotNbPerCollectible;
    }

}
