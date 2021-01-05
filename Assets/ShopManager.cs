using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] Image[] itemSlots;
    [SerializeField] InventoryObject playerInventory;

    [SerializeField] InventoryObject currentWares; //Since it's a reference to scriptable object, it will affect the wares of everybody else who references it.

    bool isOpened;

    public void BuyItem(int id)
    {
        if(currentWares != null && id >= 0 && id < currentWares.ownedGear.Count)
        {
            GearSlot gearSlot = currentWares.ownedGear[id];

            InventoryObject.TradeItem(gearSlot, playerInventory, currentWares);

            //Update UI:
            EmptySlot(id);
            GenerateIcons();

            /*
            //Exchange money
            InventoryObject.ExchangeMainCurrency(currentWares.ownedGear[id].gear.BuyPrice, playerInventory, currentWares);

            //Give item to player:
            playerInventory.AddGear(currentWares.ownedGear[id].gear);
            Debug.Log("You bought item of id: " + id);
            Debug.Log(currentWares.ownedGear[id].gear);
            
            //Remove item from current wares:
            currentWares.RemoveGear(id);
            */
            
        }
        else
        {
            Debug.Log("It's an empty slot dumbass...");
        }
        //GenerateIcons();
    }

    public void OpenShop(InventoryObject wares)
    {
        if(!isOpened)
        {
            isOpened = true;
            UpdateShop(wares);
            GenerateIcons();
        }
        else
        {
            isOpened = false;
            ClearShop();
        }
    }

    void UpdateShop(InventoryObject wares)
    {
        currentWares = wares;
    }

    void Start()
    {
        isOpened = false;
    }

    void ClearShop()
    {
        currentWares = null;
        ClearIcons();
    }

    void GenerateIcons()
    {
        if(currentWares != null)
        {
            ClearIcons();
            for(int i = 0; i < currentWares.ownedGear.Count; i++)
            {
                itemSlots[i].sprite = currentWares.ownedGear[i].gear.icon;
            }
        }
    }

    void ClearIcons()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            EmptySlot(i);
        }
    }

    void EmptySlot(int id)
    {
        itemSlots[id].sprite = null;
    }
}
