using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public GameObject c;//crosshair
    public int camMode;



    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            if (camMode == 1) {
                camMode = 0;
            }
            else
            {
                camMode += 1;
            }
        }
        StartCoroutine(CamChange());
    }

    IEnumerator CamChange() {
        yield return new WaitForSeconds(0.001f);
        if (camMode == 0) {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
            FirstCam.transform.rotation = Quaternion.identity;
            c.GetComponent<Image>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        if (camMode == 1)
        {
            ThirdCam.SetActive(false);
            FirstCam.SetActive(true);
            c.GetComponent<Image>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
