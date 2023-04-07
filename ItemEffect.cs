using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class ItemEffect : MonoBehaviour
{
    public Itemtype item;
    private void Update()
    {
        item = GetComponent<OnClickItem>().item.itemType;
    }
    public void Use()
    {
        switch (item)
        {
            default:
            case Itemtype.Beef:
                GetComponent<Health>().HungerGain(10);
                break;
            case Itemtype.Calamari:
                GetComponent<Health>().HungerGain(8);
                break;
            case Itemtype.Fish:
                GetComponent<Health>().HungerGain(5);
                break;
            case Itemtype.FortuneCookie:
                GetComponent<Health>().HungerGain(20);
                int num = Random.Range(0, 4);
                if(num == 0)
                {
                    GetComponent<Health>().IncreaseMaxHealth(10);
                }
                else if (num == 1)
                {
                    GetComponent<Health>().DecreaseMaxHealth(5);
                }
                else if(num == 2)
                {
                    GetComponent<Health>().IncreaseMaxHealth(5);
                }
                break;
            case Itemtype.Octopus:
                GetComponent<Health>().HungerGain(6);
                break;
            case Itemtype.Onigiri:
                GetComponent<Health>().HungerGain(12);
                break;
            case Itemtype.Shrimp:
                GetComponent<Health>().HungerGain(5);
                break;
            case Itemtype.Sushi:
                GetComponent<Health>().HungerGain(8);
                break;
            case Itemtype.Tealeaf: 
                GetComponent<Health>().IncreaseMaxHunger(10);
                GetComponent<Health>().HungerGain(10);
                GetComponent<Health>().IncreaseMaxHealth(5);
                break;
            case Itemtype.Emptypot:
                break;
            case Itemtype.Lifepot:
                GetComponent<Health>().HealthGain(10);
                break;
            case Itemtype.Medpack:
                GetComponent<Health>().HealthGain(25);
                break;
            case Itemtype.Milkpot:
                break;
            case Itemtype.GoldKey:
                break;
            case Itemtype.SilverKey:
                break;
            case Itemtype.Axe:
                GetComponent<PlayerAction>().SetWeaponStats(10, 0.75f, 5, 10f);
                break;
            case Itemtype.Club:
                GetComponent<PlayerAction>().SetWeaponStats(5, 0.5f, 3, 6f);
                break;
            case Itemtype.Fork:
                GetComponent<PlayerAction>().SetWeaponStats(6, 0.6f, 3, 5f);
                break;
            case Itemtype.Hammer:
                GetComponent<PlayerAction>().SetWeaponStats(25, 1f, 10, 20f);
                break;
            case Itemtype.Lance:
                GetComponent<PlayerAction>().SetWeaponStats(8, 1f, 6, 7f);
                break;
            case Itemtype.Raiper:
                GetComponent<PlayerAction>().SetWeaponStats(2, 0.5f, 1, 1f);
                return;
            case Itemtype.Stick:
                GetComponent<PlayerAction>().SetWeaponStats(2, 0.5f, 2, 2f);
                break;
            case Itemtype.Sword:
                GetComponent<PlayerAction>().SetWeaponStats(8, 0.6f, 3, 6f);
                break;
        }
    }
}

