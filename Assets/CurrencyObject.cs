using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CurrencyObject : ItemObject
{
    public int Amount 
    {
        get { return amount; }
    }

    [SerializeField] int amount;

    public void IncreaseAmount(int amount)
    {
        this.amount += amount;
    }

    public void ReduceAmount(int amount)
    {
        this.amount -= amount;
    }
}
