using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PivkUpItem(int id )
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id] );

        if ( result == true )
        {
            print("Item Added");
        }
        else
        {
            print("Item not added");
        }
    }
    
}
