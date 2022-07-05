using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBack : MonoBehaviour
{
    [SerializeField] private float cloudSpeed;
    [SerializeField] private float cloudStop;
    private float sX;
    private float sY;
    private float sZ;
    private float cloudSign;

    void Start()
    {
        sX = transform.position.x;
        sY = transform.position.y;
        sZ = transform.position.z;
        cloudSign = 1;
    }

    void Update()
    {
        transform.position = new Vector3(sX, transform.position.y + cloudSign * (cloudSpeed * Time.deltaTime), sZ);

        if(transform.position.y > sY + cloudStop || transform.position.y < sY - cloudStop)
            cloudSign = -cloudSign;
    }
}
