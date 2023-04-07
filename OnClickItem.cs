using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Item;

public class OnClickItem : MonoBehaviour
{
    public Image Helmet;
    public GameObject HelmetButt;
    public Image Chest;
    public GameObject ChestButt;
    public Image Weapon;
    public GameObject WeaponButt;
    public Image Pant;
    public GameObject PantButt;
    public Item item;
    public PlayerAction action;
    private Inventory inventory;

    public void onClick()
    {
        if (item.isEquipment())
        {
            if (item.isItemHelmet())
            {
                Helmet.gameObject.SetActive(true);
                Helmet.sprite = item.GetSprite();
                action.UseItem(item);
                HelmetButt.GetComponent<RemoveEquipment>().items = item;
            }
            if (item.isItemChest())
            {
                Chest.gameObject.SetActive(true);
                Chest.sprite = item.GetSprite();
                action.UseItem(item);
                ChestButt.GetComponent<RemoveEquipment>().items = item;

            }
            if (item.isItemWeapon())
            {
                Weapon.gameObject.SetActive(true);
                Weapon.sprite = item.GetSprite();
                action.UseItem(item);
                WeaponButt.GetComponent<RemoveEquipment>().items = item;
            }
            if (item.isItemPant())
            {
                Pant.gameObject.SetActive(true);
                Pant.sprite = item.GetSprite();
                action.UseItem(item);
                PantButt.GetComponent<RemoveEquipment>().items = item;
            }
        }
        else
        {
            action.UseItem(item);
        }
    } 
    public void DropItem()
    {
        action.Drop(item.itemType,1);
    }
}
