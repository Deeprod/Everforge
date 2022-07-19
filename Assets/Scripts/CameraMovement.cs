using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 cameraPosition;

    [Header("Camera Settings")]
    public float CameraSpeed;

    [Header("Cloud Background Lock")]
    public GameObject[] cloud;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            cameraPosition.y += CameraSpeed/10;
            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i].transform.position = new Vector3(cloud[i].transform.position.x, cloud[i].transform.position.y + CameraSpeed/10, cloud[i].transform.position.z);
            }
        }
        if(Input.GetKey(KeyCode.S))
        {
            cameraPosition.y -= CameraSpeed/10;
            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i].transform.position = new Vector3(cloud[i].transform.position.x, cloud[i].transform.position.y - CameraSpeed/10, cloud[i].transform.position.z);
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            cameraPosition.x += CameraSpeed/10;
            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i].transform.position = new Vector3(cloud[i].transform.position.x + CameraSpeed/10, cloud[i].transform.position.y, cloud[i].transform.position.z);
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            cameraPosition.x -= CameraSpeed/10;
            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i].transform.position = new Vector3(cloud[i].transform.position.x - CameraSpeed/10, cloud[i].transform.position.y, cloud[i].transform.position.z);
            }
        }
        this.transform.position = cameraPosition;
        //for (int i = 0; i < cloud.Length; i++)
        //{
        //    cloud[i].transform.position = cloudPosition[i];
        //}
    }
}
