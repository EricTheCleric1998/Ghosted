using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    bool helpEnabled = false;
    public GameObject help;
   


   void Update()
   {
        if(Input.GetKeyDown(KeyCode.H)){
          helpEnabled = !helpEnabled;  
      } 
      if(helpEnabled == true)
      {
          help.SetActive(true);
      }else{
          help.SetActive(false);
      }
   }

   public void clickH()
   {
       helpEnabled = !helpEnabled;
       if(helpEnabled == true)
       {
           help.SetActive(true);
       }else
       {
           help.SetActive(false);
       }
   }

   
}
