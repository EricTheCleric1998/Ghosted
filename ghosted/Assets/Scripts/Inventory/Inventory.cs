using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 9;
    private const int ECTOPLASM = 1;
    private List<IInventoryItem> mItems = new List<IInventoryItem>();
    private List<IInventoryItem> nEctoplasm = new List<IInventoryItem>();
    public event EventHandler<InventoryEventArgs> ItemAdded;
  

    public void AddItem(IInventoryItem item){
        if(mItems.Count < SLOTS){
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if(collider.enabled){
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickup();

                if(ItemAdded != null){
                    ItemAdded(this,new InventoryEventArgs(item));
                }
            }
        }
    }



      public void AddEctoplasm(IInventoryItem ectoplasm){
        if(nEctoplasm.Count < ECTOPLASM){
            Collider collider = (ectoplasm as MonoBehaviour).GetComponent<Collider>();
            if(collider.enabled){
                collider.enabled = false;
                nEctoplasm.Add(ectoplasm);
                ectoplasm.OnPickup();

                if(ItemAdded != null){
                    ItemAdded(this,new InventoryEventArgs(ectoplasm));
                }
            }
        }
    }

    public void checkKeys()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
