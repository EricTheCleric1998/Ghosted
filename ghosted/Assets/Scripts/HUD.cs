using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public Inventory Inventory;

    //Messing around with opening and closing the shop panel.
    public GameObject shopUI;
    public static bool shopIsOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    
        shopUI.SetActive(false);
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        Transform ectoplasmPanel = transform.Find("EctoplasmPanel");
        foreach(Transform slot in inventoryPanel)
        {
            
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
           
            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                break;
            }
        }
    }

    private void InventoryScript_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
  
        foreach(Transform slot in inventoryPanel)
        {
            
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
           
            if(image.enabled)
            {
                image.enabled = false;
                image.sprite = e.Item.Image;
                break;
            }
        }
    }

    
}
