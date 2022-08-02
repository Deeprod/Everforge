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

    private float movX;
    private float movY;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movX = 0;
        movY = 0;

        if(Input.GetKey(KeyCode.D))
        {
            movX = Mathf.Cos((Mathf.PI/180)*26.565f)/10;
            movY = -Mathf.Sin((Mathf.PI/180)*26.565f)/10;
        }
        if(Input.GetKey(KeyCode.A))
        {
            movX = -Mathf.Cos((Mathf.PI/180)*26.565f)/10;
            movY = Mathf.Sin((Mathf.PI/180)*26.565f)/10;
        }

        cameraPosition.x += movX;
        cameraPosition.y += movY;
        for (int i = 0; i < cloud.Length; i++)
        {
            cloud[i].transform.position = new Vector3(cloud[i].transform.position.x + movX, cloud[i].transform.position.y + movY, cloud[i].transform.position.z);
        }
        this.transform.position = cameraPosition;

        //for (int i = 0; i < cloud.Length; i++)
        //{
        //    cloud[i].transform.position = cloudPosition[i];
        //}
    }
}
