using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EctoplasmAddSystem : MonoBehaviour
{
  public GameObject ectoplasmText;
  public static int theNumber;
  public Button star;
  public Button lightning;
  public Button met;
  public Button judge;
  public Image notBought1;
  public Image notBought2;
  public Image notBought3;
  public Image notBought4;


  
  void Update() {
      if(theNumber <= 1000){
        ectoplasmText.GetComponent<Text>().text = "" + theNumber;
      }  
  }

  public void BuyStarfall(int cost) 
    {
      if(theNumber >= cost)
      {
        theNumber -= cost;
        star.interactable = false;
        notBought1.enabled = false;
        Abilities.isKeyEnabled1 = true;
        Debug.Log(Abilities.isKeyEnabled1);
  

      }else{
        Debug.Log("You do not have enough ectoplasm!!");
          star.interactable = true;
          notBought1.enabled = true;   
      }

    }
     public void BuyLightning(int cost) 
    {
      if(theNumber >= cost)
      {
        theNumber -= cost;
        lightning.interactable = false;
        notBought2.enabled = false;
        Abilities.isKeyEnabled2 = true;
           
      

      }else{
        Debug.Log("You do not have enough ectoplasm!!");
          lightning.interactable = true;
          notBought2.enabled = true;    
      }

    }
     public void BuyMeteorStorm(int cost) 
    {
      if(theNumber >= cost)
      {
        theNumber -= cost;
        met.interactable = false;  
        notBought3.enabled = false;
        Abilities.isKeyEnabled3 = true;  

      }else{
        Debug.Log("You do not have enough ectoplasm!!");
          met.interactable = true;  
          notBought3.enabled = true;  
      }

    }
     public void BuyJudgement(int cost) 
    {
      if(theNumber >= cost)
      {
        theNumber -= cost;
        judge.interactable = false; 
        notBought4.enabled = false;
        Abilities.isKeyEnabled4 = true;   

      }else{
        Debug.Log("You do not have enough ectoplasm!!");
          judge.interactable = true;
          notBought4.enabled = true;    
      }

    }
}
