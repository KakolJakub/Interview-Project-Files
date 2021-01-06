using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    
    public CharacterSkinObject skin;
    [SerializeField] CharacterSkinObject defaultSkin;

    [SerializeField] ShopManager shop;
    [SerializeField] InventoryManager inventoryMenu;

    public void BuyItem(EquipmentObject eq)
    {
        inventory.AddGear(eq);
    }

    public void SellItem(int id)
    {
        if(InventoryObject.CheckId(id, inventory))
        {
            if(inventory.ownedGear[id].isEquipped)
            {
                UnequipItem(id);
                Debug.Log("Item unequipped");
            }
        }
    }

    public void InteractWithItem(int id)
    {   
        if(InventoryObject.CheckId(id, inventory))
        {
            if(inventory.ownedGear[id].isEquipped)
            {
                UnequipItem(id);
            }
            else
            {
                EquipItem(id);
            }
        }
    }

    void EquipItem(int id)
    {
        if(InventoryObject.CheckId(id, inventory))
        {
            MySpriteSheet newSkin = inventory.ownedGear[id].gear.Skin;
            CharacterSkinObject.ChangeSkin(skin, newSkin);
            inventory.ownedGear[id].isEquipped = true;
        }
    }

    void UnequipItem(int id)
    {
        if(InventoryObject.CheckId(id, inventory))
        {
            MySpriteSheet newSkin = inventory.ownedGear[id].gear.Skin;
            MySpriteSheet defaultPart = defaultSkin.GetBodySheet(newSkin.BodyPart);
            CharacterSkinObject.ChangeSkin(skin, defaultPart);
            inventory.ownedGear[id].isEquipped = false;
        }
    }

    void Awake()
    {
        CharacterSkinObject.CopySkin(defaultSkin, skin);
    }

    void Update() //test only
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            shop.OpenShop(inventory);
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryMenu.EnableMenu();
        }
    }

    void OnApplicationQuit()
    {
        inventory.ownedGear.Clear();
        skin.bodySpriteSheets.Clear();
        //inventory.ownedCurrencies.Clear();
    }

}
