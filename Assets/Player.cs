using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;

    public void BuyItem(EquipmentObject eq)
    {
        inventory.AddGear(eq);
    }

    private void OnApplicationQuit()
    {
        inventory.ownedGear.Clear();
        //inventory.ownedCurrencies.Clear();
    }
}
