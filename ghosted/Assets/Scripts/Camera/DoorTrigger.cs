using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    bool isOpen = false;
     void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Pickable") {
            Debug.Log("Open up Bitch!");
            if (!isOpen)
            {
                door.transform.position += new Vector3(0, 4.0f, 0);//moves door
                isOpen = true;
                gameObject.transform.position+= new Vector3(0, -.2f, 0);
            }
        }
        
        
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Pickable")
        {
            if (isOpen) { }
            Debug.Log("Open up Bitch!");
            door.transform.position += new Vector3(0, -4.0f, 0);//moves door
            isOpen = false;
            gameObject.transform.position += new Vector3(0, .2f, 0);
        } }
    
}
