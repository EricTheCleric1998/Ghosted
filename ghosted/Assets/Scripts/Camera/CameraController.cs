using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform cameraJig;

    private Vector3 offset;
    public float coolDown = .3f;

    
    public float rotateSpeed;
    public float speed = 50.0f;
    public bool canPress = true;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
        
    }
   

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - offset;
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.RotateAround(cameraJig.position, Vector3.up, 90.0f);
            offset = target.position - transform.position; 
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.RotateAround(cameraJig.position, -Vector3.up, -90.0f);
            offset = target.position - transform.position;         
        }
    }
}
