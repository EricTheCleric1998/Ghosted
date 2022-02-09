using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_01 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    void Start()
    {
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Debug.Log("hi");
    }
}
