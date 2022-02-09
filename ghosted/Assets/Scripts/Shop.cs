using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
   private bool shopEnabled;
   public GameObject shop;
   private int allSlots;
   private int enabledSlots;
   private GameObject[] slot;
   public GameObject slotHolder;


   void Start() 
   {  
      allSlots = 5; 
      slot = new GameObject[allSlots];
      for(int i = 0; i < allSlots-1; i++)
      {
          slot[i] = slotHolder.transform.GetChild(i).gameObject;
      }
   }

   void Update() 
   {
      if(Input.GetKeyDown(KeyCode.R)){
          shopEnabled = !shopEnabled;  
      } 
      if(shopEnabled == true)
      {
          shop.SetActive(true);
      }else{
          shop.SetActive(false);
      }
   }

     public void clickR()
   {
       shopEnabled = !shopEnabled;
       if(shopEnabled == true)
       {
           shop.SetActive(true);
       }else
       {
           shop.SetActive(false);
       }
   }
}
