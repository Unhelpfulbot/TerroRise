using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public event EventHandler OnItemListChange;
    public List<Item> itemlist;
    public List<Item> equipment;
    private Action<Item> UseitemAction;
    public Inventory(Action<Item> UseitemAction)
    {
        this.UseitemAction = UseitemAction;
        itemlist = new List<Item>();
        equipment = new List<Item>();
    }
    public void Additem(Item item)
    {
        if (item.isStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryitem in itemlist)
            {
                if (inventoryitem.itemType == item.itemType)
                {
                    inventoryitem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemlist.Add(item);
            }
        }
        else
        {
            itemlist.Add(item);
        }
            OnItemListChange?.Invoke(this, EventArgs.Empty);
    }
    public List<Item> GetItemList()
    {
        return itemlist;
    }
    public List<Item> Equipment()
    {
        foreach (Item item in itemlist)
        {
            if (item.isEquipment())
            {
                equipment.Add(item);
            }
        }
        return equipment;
    }
    public void RemoveItem(Item item)
    {
            Item iteminInventory = null;
            foreach (Item inventoryitem in itemlist)
            {
                if (inventoryitem.itemType == item.itemType)
                {
                    inventoryitem.amount -= item.amount;
                    iteminInventory = inventoryitem;
                }
            }
            if ((iteminInventory != null) && (iteminInventory.amount <= 0))
            {
                itemlist.Remove(iteminInventory);
            }
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }
    public void UseItem(Item item)
    {
        UseitemAction(item);
    }
    public void DropItem(Item item, Vector3 pos)
    {
        RemoveItem(item);
        ItemWorld.SpawnItem(pos, item);
    }
}
