using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{

    public Transform target;
    private Vector3 offset;
    void Start()
    {
        offset = target.position - transform.position;

    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.RotateAround(target.position, Vector3.up, 180.0f);
            //target.transform.Rotate(0,90,0,Space.Self);
            //target.transform.rotation *= Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = target.position - offset;

    }
}
