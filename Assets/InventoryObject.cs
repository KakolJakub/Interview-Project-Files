using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryObject : ScriptableObject
{
    public List<GearSlot> ownedGear = new List<GearSlot>();
    public CurrencyObject mainCurrency;

    //public List<CurrencyObject> ownedCurrencies = new List<CurrencyObject>(); //if the list owns the currency, add its value

    public void AddGear(EquipmentObject gear)
    {
        ownedGear.Add(new GearSlot(gear));
    }

    public void RemoveGear(GearSlot gearSlot)
    {
        ownedGear.Remove(gearSlot);
    }

    public void RemoveGear(int id)
    {
        ownedGear.RemoveAt(id);
    }

    /*
    public void IncreaseMainCurrency(int amount)
    {
        mainCurrency.IncreaseAmount(amount);
    }

    public void ReduceMainCurrency(int amount)
    {
        mainCurrency.Reduce(amount);
    }
    */

    public static bool ExchangeMainCurrency(int amount, InventoryObject buyerInv, InventoryObject sellerInv)
    {
        bool success;

        if(buyerInv.mainCurrency.Amount >= amount)
        {
            buyerInv.mainCurrency.ReduceAmount(amount);
            sellerInv.mainCurrency.IncreaseAmount(amount);
            success = true;
        }
        else
        {
            success = false;
            Debug.Log("Exchange failed. Not enough main currency.");
        }
        return success;
    }

    public static void TradeItem(GearSlot gearSlot, InventoryObject buyerInv, InventoryObject sellerInv)
    {
        EquipmentObject eq = gearSlot.gear;
        int itemPrice = eq.BuyPrice;
        
        if(ExchangeMainCurrency(itemPrice, buyerInv, sellerInv))
        {
            buyerInv.AddGear(eq);
            Debug.Log("You acquired an item: " + eq);
            sellerInv.RemoveGear(gearSlot);
        }
        else
        {
            Debug.Log("Trade failed.");
        }
    }

    /*
    public void AddCurrency(CurrencyObject currency)
    {
        for(int i = 0; i < ownedCurrencies.Count; i++)
        {
            if(ownedCurrencies[i] == currency)
            {
                ownedCurrencies[i].IncreaseAmount(currency.Amount);
                break;
            }
        }
    }
    */
}

[System.Serializable]
public class GearSlot
{
    public EquipmentObject gear;

    public GearSlot(EquipmentObject gear)
    {
        this.gear = gear;
    }
}
