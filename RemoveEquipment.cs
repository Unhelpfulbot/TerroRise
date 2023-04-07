using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveEquipment : MonoBehaviour
{
    public Item items;
    public Image img;
    public Sprite nothing;
    public Health health;
    public PlayerAction action;
    private Inventory inventory;
    public Item.Itemtype type;
    public void Update()
    {
        type = items.itemType;
    }

    public void Onclick()
    {
        if (items.isItemHelmet())
        {
            img.sprite = nothing;
            health.HArmor = 0;
            action.AddEquippedItem(type, 1);
        }
        if (items.isItemChest())
        {
            img.sprite = nothing;
            health.CArmor = 0;
            action.AddEquippedItem(type, 1);
        }
        if (items.isItemWeapon())
        {
            img.sprite = nothing;
            action.SetWeaponStats(1,0.5f,1,0.5f);
            action.AddEquippedItem(type, 1);
        }
        if (items.isItemPant())
        {
            img.sprite = nothing;
            health.LArmor = 0;
            action.AddEquippedItem(type, 1);
        }
    }
}
