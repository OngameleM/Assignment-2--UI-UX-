using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int MaxStackedItems = 4;
    public ItemSlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public bool AddItem(Item item )
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            ItemSlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();

            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < MaxStackedItems && itemInSlot.item.stackable == true)
            {
               itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }

        }
        for (int i =  0; i < inventorySlots.Length; i++)
        {
            ItemSlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();

            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }

        }
        return false;
    }

    void SpawnNewItem(Item item, ItemSlot slot ) 
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DraggableItem inventoryItem = newItemGo.GetComponent<DraggableItem>();
        inventoryItem.InitialiseItem(item);
    
    }

    
    
}
