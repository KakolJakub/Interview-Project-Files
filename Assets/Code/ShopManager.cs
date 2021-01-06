using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject shopMenu;

    [SerializeField] InventoryObject playerInventory;
    [SerializeField] Image[] itemSlots;

    [SerializeField] InventoryObject currentWares;

    bool isOpened;

    public void EnableMenu(bool isEnabled)
    {
        shopMenu.SetActive(isEnabled);
    }

    public void BuyItem(int id)
    {
        if(currentWares != null && id >= 0 && id < currentWares.ownedGear.Count)
        {
            GearSlot gearSlot = currentWares.ownedGear[id];

            InventoryObject.TradeItem(gearSlot, playerInventory, currentWares);

            //Update UI:
            EmptySlot(id);
            GenerateIcons();
            
            if(this.name == "ShopMenu")
            {
                Debug.Log("UI updated: " + this.name);
            }
        }
        else
        {
            //Debug.Log("It's an empty slot...");
        }
    }

    public void SellItem(int id)
    {
        if(currentWares != null && id >= 0 && id < currentWares.ownedGear.Count)
        {
            GearSlot gearSlot = currentWares.ownedGear[id];
            gearSlot.isEquipped = false;
            
            InventoryObject.ExchangeItemForCurrency(gearSlot, currentWares, currentWares.mainCurrency);

            //Update UI:
            EmptySlot(id);
            GenerateIcons();

            if(this.name == "ShopMenu")
            {
                Debug.Log("UI updated: " + this.name);
            }
        }
        else
        {
            //Debug.Log("It's an empty slot...");
        }
    }

    public void OpenShop(InventoryObject wares)
    {
        if(!isOpened)
        {
            isOpened = true;
            UpdateShop(wares);
            GenerateIcons();
            EnableMenu(true);
        }
        else
        {
            isOpened = false;
            ClearShop();
            EnableMenu(false);
        }
    }

    public void GenerateIcons()
    {
        if(currentWares != null)
        {
            ClearIcons();
            for(int i = 0; i < currentWares.ownedGear.Count; i++)
            {
                itemSlots[i].sprite = currentWares.ownedGear[i].gear.icon;
            }
        }
        else
        {
            ClearIcons();
            //Debug.Log("It should be empty...");
        }

        //Debug.Log("Icons generated: " + this.name);
    }
    
    void UpdateShop(InventoryObject wares)
    {
        currentWares = wares;
    }

    void Start()
    {
        isOpened = false;
        EnableMenu(false);
    }

    void ClearShop()
    {
        currentWares = null;
        ClearIcons();
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
