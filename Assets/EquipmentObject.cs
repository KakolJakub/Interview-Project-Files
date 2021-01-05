using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EquipmentObject : ItemObject
{
    [SerializeField] Sprite skin;

    public int BuyPrice { get { return buyPrice;} }
    [SerializeField] int buyPrice;

    public int SellPrice { get { return sellPrice;} }
    [SerializeField] int sellPrice;
}
