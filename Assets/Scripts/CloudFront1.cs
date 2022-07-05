using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFront1 : MonoBehaviour
{
    [SerializeField] private float cloudSpeed;
    [SerializeField] private float cloudRespawn;
    private float sX;
    private float sY;
    private float sZ;

    void Start()
    {
        sX = transform.position.x;
        sY = transform.position.y;
        sZ = transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + cloudSpeed * Time.deltaTime, sY, sZ);

        if(transform.position.x > sX + cloudRespawn)
            transform.position = new Vector3(sX, sY, sZ);
    }
}
