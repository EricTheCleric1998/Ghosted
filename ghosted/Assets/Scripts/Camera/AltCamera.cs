using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCamera : MonoBehaviour
{

    public Transform target;
    public Transform cameraJig;

    private Vector3 offset;

    float speedH = 2.0f;
    float speedV = 2.0f;

    float yaw = 0.0f;
    float pitch = 0.0f;


    void Update()
    {

       

        yaw -= speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }



    /*[SerializeField]
    float mouseSensitivity;
    float xAxisClamp = 0;

    [SerializeField]
    Transform player;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RotateCamera();
    }
    void RotateCamera() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountX;

        Vector3 rotPlayer = player.transform.rotation.eulerAngles;
        rotPlayer.x = rotAmountY;
        rotPlayer.z = 0;
        rotPlayer.y += rotAmountX;
       
        player.rotation = Quaternion.Euler(rotPlayer);
    }*/
}
