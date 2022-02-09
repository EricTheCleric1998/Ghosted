using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    float speedH = 2.0f;
    float speedV = 2.0f;

    float yaw = 0.0f;
    float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;

    }
    void Update()
    {

        /*yaw -= speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);*/
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = target.position - offset;
       
    }
}
