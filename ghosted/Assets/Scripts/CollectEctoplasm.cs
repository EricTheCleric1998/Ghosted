using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEctoplasm : MonoBehaviour
{
  private int maxEctoplasm = 1000;
  public static int counter;
  
    void OnTriggerEnter(Collider other) {
      counter = EctoplasmAddSystem.theNumber += 50;
      if(counter <= maxEctoplasm){
         Destroy(gameObject);
      }
  }

}
