using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item 
{
    public enum Itemtype
    {
        GoldKey,
        SilverKey,
        Beef,
        Calamari,
        Fish,
        FortuneCookie,
        Octopus,
        Onigiri,
        Shrimp,
        Sushi,
        Tealeaf,
        Emptypot,
        Lifepot,
        Medpack,
        Milkpot,
        Axe,
        Club,
        Fork,
        Hammer,
        Lance,
        Raiper,
        Stick,
        Sword,
        WHelmet,
        CHelmet,
        IHelmet,
        RHelmet,
        WChest,
        CChest,
        IChest,
        RChest,
        WLeg,
        CLeg,
        ILeg,
        RLeg
    }
    public Itemtype itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case Itemtype.GoldKey: return ItemAssest.Instance.GoldKeysprite;
            case Itemtype.SilverKey: return ItemAssest.Instance.SilverKeysprite;
            case Itemtype.Beef: return ItemAssest.Instance.Beefsprite;
            case Itemtype.Calamari: return ItemAssest.Instance.Calamarisprite;
            case Itemtype.Fish: return ItemAssest.Instance.Fishsprite;
            case Itemtype.FortuneCookie: return ItemAssest.Instance.FortuneCookiesprite;
            case Itemtype.Octopus: return ItemAssest.Instance.Octopussprite;
            case Itemtype.Onigiri: return ItemAssest.Instance.Onigirisprite;
            case Itemtype.Shrimp: return ItemAssest.Instance.Shrimpsprite;
            case Itemtype.Sushi: return ItemAssest.Instance.Sushisprite;
            case Itemtype.Tealeaf: return ItemAssest.Instance.Tealeafsprite;
            case Itemtype.Emptypot: return ItemAssest.Instance.Emptypotsprite;
            case Itemtype.Lifepot: return ItemAssest.Instance.Lifepotsprite;
            case Itemtype.Medpack: return ItemAssest.Instance.Medpacksprite;
            case Itemtype.Milkpot: return ItemAssest.Instance.Milkpotsprite;
            case Itemtype.Axe: return ItemAssest.Instance.Axesprite;
            case Itemtype.Club: return ItemAssest.Instance.Clubsprite;
            case Itemtype.Fork: return ItemAssest.Instance.Forksprite;
            case Itemtype.Hammer: return ItemAssest.Instance.Hammersprite;
            case Itemtype.Lance: return ItemAssest.Instance.Lancesprite;
            case Itemtype.Raiper: return ItemAssest.Instance.Raipersprite;
            case Itemtype.Stick: return ItemAssest.Instance.Sticksprite;
            case Itemtype.Sword: return ItemAssest.Instance.Swordsprite;
            case Itemtype.WHelmet: return ItemAssest.Instance.WHelmetsprite;
            case Itemtype.CHelmet: return ItemAssest.Instance.CHelmetsprite;
            case Itemtype.IHelmet: return ItemAssest.Instance.IHelmetsprite;
            case Itemtype.RHelmet: return ItemAssest.Instance.RHelmetsprite;
            case Itemtype.WChest: return ItemAssest.Instance.WChestsprite;
            case Itemtype.CChest: return ItemAssest.Instance.CChestsprite;
            case Itemtype.IChest: return ItemAssest.Instance.IChestsprite;
            case Itemtype.RChest: return ItemAssest.Instance.RChestsprite;
            case Itemtype.WLeg: return ItemAssest.Instance.WLegsprite;
            case Itemtype.CLeg: return ItemAssest.Instance.CLegsprite;
            case Itemtype.ILeg: return ItemAssest.Instance.ILegsprite;
            case Itemtype.RLeg: return ItemAssest.Instance.RLegsprite;

        }
    }
    public bool isStackable()
    {
        switch (itemType)
        {
            default:
            case Itemtype.Beef:
            case Itemtype.Calamari:
            case Itemtype.Fish:
            case Itemtype.FortuneCookie:
            case Itemtype.Octopus:
            case Itemtype.Onigiri:
            case Itemtype.Shrimp:
            case Itemtype.Sushi:
            case Itemtype.Tealeaf:
            case Itemtype.Emptypot:
            case Itemtype.Lifepot:
            case Itemtype.Medpack:
            case Itemtype.Milkpot:
                return true;
            case Itemtype.GoldKey:
            case Itemtype.SilverKey:
            case Itemtype.Axe:
            case Itemtype.Club:
            case Itemtype.Fork:
            case Itemtype.Hammer:
            case Itemtype.Lance:
            case Itemtype.Raiper:
            case Itemtype.Stick:
            case Itemtype.Sword:
            case Itemtype.WHelmet:
            case Itemtype.CHelmet:
            case Itemtype.IHelmet:
            case Itemtype.RHelmet:
            case Itemtype.WChest:
            case Itemtype.CChest:
            case Itemtype.IChest:
            case Itemtype.RChest:
            case Itemtype.WLeg:
            case Itemtype.CLeg:
            case Itemtype.ILeg:
            case Itemtype.RLeg:
                return false;
        }
    }
    public bool isEquipment()
    {
        switch (itemType)
        {
            default:
            case Itemtype.Beef:
            case Itemtype.Calamari:
            case Itemtype.Fish:
            case Itemtype.FortuneCookie:
            case Itemtype.Octopus:
            case Itemtype.Onigiri:
            case Itemtype.Shrimp:
            case Itemtype.Sushi:
            case Itemtype.Tealeaf:
            case Itemtype.Emptypot:
            case Itemtype.Lifepot:
            case Itemtype.Medpack:
            case Itemtype.Milkpot:
            case Itemtype.GoldKey:
            case Itemtype.SilverKey:
                return false;
            case Itemtype.Axe:
            case Itemtype.Club:
            case Itemtype.Fork:
            case Itemtype.Hammer:
            case Itemtype.Lance:
            case Itemtype.Raiper:
            case Itemtype.Stick:
            case Itemtype.Sword:
            case Itemtype.WHelmet:
            case Itemtype.CHelmet:
            case Itemtype.IHelmet:
            case Itemtype.RHelmet:
            case Itemtype.WChest:
            case Itemtype.CChest:
            case Itemtype.IChest:
            case Itemtype.RChest:
            case Itemtype.WLeg:
            case Itemtype.CLeg:
            case Itemtype.ILeg:
            case Itemtype.RLeg:
                return true;
        }
    }
    public bool isItemHelmet()
    {
        switch (itemType)
        {
            default:
            case Itemtype.Axe:
            case Itemtype.Club:
            case Itemtype.Fork:
            case Itemtype.Hammer:
            case Itemtype.Lance:
            case Itemtype.Raiper:
            case Itemtype.Stick:
            case Itemtype.Sword:
                return false;
            case Itemtype.WHelmet:
            case Itemtype.CHelmet:
            case Itemtype.IHelmet:
            case Itemtype.RHelmet:
                return true;
        }
    }
    public bool isItemChest()
    {
        switch (itemType)
        {
            default:
            case Itemtype.Axe:
            case Itemtype.Club:
            case Itemtype.Fork:
            case Itemtype.Hammer:
            case Itemtype.Lance:
            case Itemtype.Raiper:
            case Itemtype.Stick:
            case Itemtype.Sword:
                return false;
            case Itemtype.WChest:
            case Itemtype.CChest:
            case Itemtype.IChest:
            case Itemtype.RChest:
                return true;
        }
    }
    public bool isItemWeapon()
    {
            switch (itemType)
        {
            default :
            case Itemtype.WHelmet:
            case Itemtype.CHelmet:
            case Itemtype.IHelmet:
            case Itemtype.RHelmet:
            case Itemtype.WChest:
            case Itemtype.CChest:
            case Itemtype.IChest:
            case Itemtype.RChest:
            case Itemtype.WLeg:
            case Itemtype.CLeg:
            case Itemtype.ILeg:
            case Itemtype.RLeg:
                return false;
            case Itemtype.Club:
            case Itemtype.Fork:
            case Itemtype.Hammer:
            case Itemtype.Axe:
            case Itemtype.Lance:
            case Itemtype.Raiper:
            case Itemtype.Stick:
            case Itemtype.Sword:
                 return true;
            }
        }
    public bool isItemPant()
    {
        switch (itemType)
        {
            default:
            case Itemtype.Axe:
            case Itemtype.Club:
            case Itemtype.Fork:
            case Itemtype.Hammer:
            case Itemtype.Lance:
            case Itemtype.Raiper:
            case Itemtype.Stick:
            case Itemtype.Sword:
                return false;
            case Itemtype.WLeg:
            case Itemtype.CLeg:
            case Itemtype.ILeg:
            case Itemtype.RLeg:
                return true;
        }
    }
}
