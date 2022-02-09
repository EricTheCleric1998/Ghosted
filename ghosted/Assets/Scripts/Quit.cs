using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) {
        Application.Quit();
    }
    }
}
