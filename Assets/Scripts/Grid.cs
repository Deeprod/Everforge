using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private float speed;
    private float progress;
    private Vector3 positionStart;
    private Vector3 positionEnd;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {

        if(Input.GetKey(KeyCode.G))
        {

            gameObject.SetActive(true);

        }
    }
}
