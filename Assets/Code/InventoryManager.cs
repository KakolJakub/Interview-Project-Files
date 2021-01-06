using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] InventoryObject inventory;

    [SerializeField] Material equippedGearMaterial; //PH
    [SerializeField] Material unequippedGearMaterial; //PH

    [SerializeField] GameObject inventoryMenu;

    [SerializeField] Image[] itemSlots;
    
    [SerializeField] Image currencySlot;
    [SerializeField] TextMeshProUGUI currencyAmount;

    public void EnableMenu(bool isEnabled)
    {
        inventoryMenu.SetActive(isEnabled);
    }

    public void EnableMenu()
    {
        if(inventoryMenu.active)
        {
            inventoryMenu.SetActive(false);
        }
        else
        {
            inventoryMenu.SetActive(true);
            UpdateIcons();
        }
    }

    public void UpdateIcons()
    {
        if(inventory != null)
        {
            if(inventory.ownedGear.Count != 0)
            {
                ClearIcons();

                for(int i = 0; i < inventory.ownedGear.Count; i++)
                {
                    itemSlots[i].sprite = inventory.ownedGear[i].gear.icon;
                    Debug.Log("Not empty because: " + inventory.ownedGear.Count);
                }
            }
            else
            {
                ClearAllIcons();
                Debug.Log("REMOVE ICONS");
            }
            Debug.Log("Icons were updated");
            UpdateCurrency();
        }
    }

    public void ShowEquipped()
    {
        for(int i = 0; i < inventory.ownedGear.Count; i++)
        {
            if(inventory.ownedGear[i].isEquipped)
            {
                //itemSlots[i].material = equippedGearMaterial;
                Debug.Log("Equipped item: " + inventory.ownedGear[i]);
            }
            else
            {
                //itemSlots[i].material = unequippedGearMaterial;
                Debug.Log("Item is not equipped: " + inventory.ownedGear[i]);
            }
        }
    }

    public void ClearIcons()
    {
        for(int i = 0; i < inventory.ownedGear.Count; i++)
        {
            itemSlots[i].sprite = null;
        }
    }

    void UpdateCurrency()
    {
        currencySlot.sprite = inventory.mainCurrency.icon;
        Debug.Log(inventory.mainCurrency.icon);
        currencyAmount.text = inventory.mainCurrency.Amount.ToString();
    }

    void ClearAllIcons() 
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].sprite = null;
        }
    }

    void Start()
    {
        EnableMenu(false);
    }


}
