using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EquipmentObject : ItemObject
{
    public MySpriteSheet Skin { get { return skin;} }
    [SerializeField] MySpriteSheet skin;

    public int BuyPrice { get { return buyPrice;} }
    [SerializeField] int buyPrice;

    public int SellPrice { get { return sellPrice;} }
    [SerializeField] int sellPrice;
}
