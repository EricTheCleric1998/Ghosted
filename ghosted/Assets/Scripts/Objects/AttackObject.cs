using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : MonoBehaviour
{
    int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") {
            Destroy(gameObject); 
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
