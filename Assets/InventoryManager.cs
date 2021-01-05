using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] InventoryObject inventory;
    [SerializeField] Image[] itemSlots;

    public void UpdateIcons()
    {
        if(inventory != null)
        {
            ClearIcons();
            for(int i = 0; i < inventory.ownedGear.Count; i++)
            {
                itemSlots[i].sprite = inventory.ownedGear[i].gear.icon;
            }
        }
    }

    public void DisplayItem(int id)
    {
        if(!(id >= inventory.ownedGear.Count) && !(id < 0))
        {
            Debug.Log("You are looking at: " + inventory.ownedGear[id].gear);
        }
        
    }

    public void ClearIcons()
    {
        for(int i = 0; i < inventory.ownedGear.Count; i++)
        {
            itemSlots[i].sprite = null;
        }
    }
}
