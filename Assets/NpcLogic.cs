using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLogic : MonoBehaviour
{
    [SerializeField] InventoryObject defaultWares;
    [SerializeField] InventoryObject wares;
    
    ShopManager shop;

    void Start()
    {
        UpdateWares();
        shop = GameObject.Find("ShopMenu").GetComponent<ShopManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            shop.OpenShop(wares);
        }
    }

    void UpdateWares()
    {
        wares.ownedGear.Clear();
        //wares.ownedCurrencies.Clear();

        for(int i = 0; i < defaultWares.ownedGear.Count; i++)
        {
            wares.ownedGear.Add(defaultWares.ownedGear[i]);
        }

        /*
        for(int i = 0; i < defaultWares.ownedCurrencies.Count; i++)
        {
            wares.ownedCurrencies.Add(defaultWares.ownedCurrencies[i]);
        }
        */
    }

}
