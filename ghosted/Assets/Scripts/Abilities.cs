using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 2;
    bool isCooldown = false;
    public KeyCode ability1;
       
    [Header("Ability 2")]
    public Image abilityImage2;
    public float cooldown2 = 5;
    bool isCooldown2 = false;
    public KeyCode ability2;

    [Header("Ability 3")]
    public Image abilityImage3;
    public float cooldown3 = 10;
    bool isCooldown3 = false;
    public KeyCode ability3;

    [Header("Ability 4")]
    public Image abilityImage4;
    public float cooldown4 = 20;
    bool isCooldown4 = false;
    public KeyCode ability4;
    


    public static bool isKeyEnabled1 = false;
    public static bool isKeyEnabled2 = false;
    public static bool isKeyEnabled3 = false;
    public static bool isKeyEnabled4 = false;
    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage4.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(isKeyEnabled1)
        {
             Ability1();
        }
         if(isKeyEnabled2)
        {
             Ability2();
        }
       
        if(isKeyEnabled3)
        {
             Ability3();
        }
       
        if(isKeyEnabled4)
        {
             Ability4();
        }
    
    }

    public void Ability1()
    {
        if(isKeyEnabled1){
            if(Input.GetKey(ability1) && isCooldown == false)
             {
                    isCooldown = true;
                    abilityImage1.fillAmount = 1;
             }
            if(isCooldown)
             {
                    abilityImage1.fillAmount -= 1/cooldown1 * Time.deltaTime;
            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }  
        }
    }

 
      void Ability2()
    {
        if(isKeyEnabled2){
        if(Input.GetKey(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }
        if(isCooldown2)
        {
            abilityImage2.fillAmount -= 1/cooldown2 * Time.deltaTime;
            if(abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
        }
    }
      void Ability3()
    {
        if(isKeyEnabled3){
        if(Input.GetKey(ability3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }
        if(isCooldown3)
        {
            abilityImage3.fillAmount -= 1/cooldown3 * Time.deltaTime;
            if(abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
        }
    }
      void Ability4()
    {
        if(isKeyEnabled4){
        if(Input.GetKey(ability4) && isCooldown4 == false)
        {
            isCooldown4 = true;
            abilityImage4.fillAmount = 1;
        }
        if(isCooldown4)
        {
            abilityImage4.fillAmount -= 1/cooldown4 * Time.deltaTime;
            if(abilityImage4.fillAmount <= 0)
            {
                abilityImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }
    }
    }
}
