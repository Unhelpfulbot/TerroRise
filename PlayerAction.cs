using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    //Keys
    public bool GoldKey = false;
    public bool SilverKey = false;

    //Att Stats
    public int Weapondmg;
    public float timebtwAtt;
    public float SwingTime;

    public Transform attackpos;
    public Transform attcircle;
    public GameObject circle;
    public LayerMask Enemy;
    public float attrange;
    public int hungercoms;

    //Inventory
    [SerializeField] private UI_inventory uiInventory;
    public Inventory inventory;

    Animator anim;
    private void Awake()
    {
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
        attcircle.localScale = new Vector2((float)attrange, (float)attrange);
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Time.time >= timebtwAtt)
        {
            circle.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Collider2D[] enemytoatt = Physics2D.OverlapCircleAll(attackpos.position, attrange, Enemy);
                if (enemytoatt.Length <= 0)
                {
                    return;
                }
                anim.SetInteger("Attack", 1);
                circle.SetActive(false);
                timebtwAtt = Time.time + SwingTime;
                for (int i = 0; i < enemytoatt.Length; i++)
                {
                    if (enemytoatt[i].GetComponent<MonsterStat>() == true)
                    {
                        enemytoatt[i].GetComponent<MonsterStat>().TakenDamage(Weapondmg);
                        GetComponent<Health>().HungerLost(hungercoms);
                    }
                }
            }
        }
    }
    
    public void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.Itemtype.Beef:
                GetComponent<Health>().HungerGain(10);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Beef, amount = 1});
                break;
            case Item.Itemtype.Calamari:
                GetComponent<Health>().HungerGain(8);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Calamari, amount = 1 });
                break;
            case Item.Itemtype.Fish:
                GetComponent<Health>().HungerGain(5);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Fish, amount = 1 });
                break;
            case Item.Itemtype.FortuneCookie:
                GetComponent<Health>().HungerGain(20);
                int num = Random.Range(0, 4);
                if (num == 0)
                {
                    GetComponent<Health>().IncreaseMaxHealth(10);
                }
                else if (num == 1)
                {
                    GetComponent<Health>().DecreaseMaxHealth(5);
                }
                else if (num == 2)
                {
                    GetComponent<Health>().IncreaseMaxHealth(5);
                }
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.FortuneCookie, amount = 1 });
                break;
            case Item.Itemtype.Octopus:
                GetComponent<Health>().HungerGain(6);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Octopus, amount = 1 });
                break;
            case Item.Itemtype.Onigiri:
                GetComponent<Health>().HungerGain(12); 
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Onigiri, amount = 1 });
                break;
            case Item.Itemtype.Shrimp:
                GetComponent<Health>().HungerGain(5);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Shrimp, amount = 1 });
                break;
            case Item.Itemtype.Sushi:
                GetComponent<Health>().HungerGain(8);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Sushi, amount = 1 });
                break;
            case Item.Itemtype.Tealeaf:
                GetComponent<Health>().IncreaseMaxHunger(10);
                GetComponent<Health>().HungerGain(10);
                GetComponent<Health>().IncreaseMaxHealth(5);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Tealeaf, amount = 1 });
                break;
            case Item.Itemtype.Emptypot:
                break;
            case Item.Itemtype.Lifepot:
                GetComponent<Health>().HealthGain(10);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Lifepot, amount = 1 });
                break;
            case Item.Itemtype.Medpack:
                GetComponent<Health>().HealthGain(25);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Medpack, amount = 1 });
                break;
            case Item.Itemtype.Milkpot:
                break;
            case Item.Itemtype.GoldKey:
                break;
            case Item.Itemtype.SilverKey:
                break;
            case Item.Itemtype.Axe:
                SetWeaponStats(10, 0.75f, 5, 7f);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Axe, amount = 1 });
                break;
            case Item.Itemtype.Club:
                SetWeaponStats(5, 0.5f, 3, 3f);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Club, amount = 1 });
                break;
            case Item.Itemtype.Fork:
                SetWeaponStats(6, 0.6f, 3, 3f);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Fork, amount = 1 });
                break;
            case Item.Itemtype.Hammer:
                SetWeaponStats(25, 1f, 10, 8f);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Hammer, amount = 1 });
                break;
            case Item.Itemtype.Lance:
                SetWeaponStats(8, 1f, 6, 4f);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Lance, amount = 1 });
                break;
            case Item.Itemtype.Raiper:
                SetWeaponStats(2, 0.5f, 1, 0.5f);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Raiper, amount = 1 });
                return;
            case Item.Itemtype.Stick:
                SetWeaponStats(2, 0.5f, 2, 1f);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Stick, amount = 1 });
                break;
            case Item.Itemtype.Sword:
                SetWeaponStats(8, 0.6f, 3, 2f);
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.Sword, amount = 1 });
                break;
            case Item.Itemtype.WHelmet:
                GetComponent<Health>().HArmor = 0.5f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.WHelmet, amount = 1 });
                break;
            case Item.Itemtype.CHelmet:
                GetComponent<Health>().HArmor = 1f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.CHelmet, amount = 1 });
                break;
            case Item.Itemtype.IHelmet:
                GetComponent<Health>().HArmor = 1.5f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.IHelmet, amount = 1 });
                break;
            case Item.Itemtype.RHelmet:
                GetComponent<Health>().HArmor = 2.5f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.RHelmet, amount = 1 });
                break;
            case Item.Itemtype.WChest:
                GetComponent<Health>().CArmor = 1f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.WChest, amount = 1 });
                break;
            case Item.Itemtype.CChest:
                GetComponent<Health>().CArmor = 1.5f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.CChest, amount = 1 });
                break;
            case Item.Itemtype.IChest:
                GetComponent<Health>().CArmor = 2.5f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.IChest, amount = 1 });
                break;
            case Item.Itemtype.RChest:
                GetComponent<Health>().CArmor = 4f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.RChest, amount = 1 });
                break;
            case Item.Itemtype.WLeg:
                GetComponent<Health>().LArmor = 0.5f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.WLeg, amount = 1 });
                break;
            case Item.Itemtype.CLeg:
                GetComponent<Health>().LArmor = 1f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.CLeg, amount = 1 });
                break;
            case Item.Itemtype.ILeg:
                GetComponent<Health>().LArmor = 1.5f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.ILeg, amount = 1 });
                break;
            case Item.Itemtype.RLeg:
                GetComponent<Health>().LArmor = 2.5f;
                inventory.RemoveItem(new Item { itemType = Item.Itemtype.RLeg, amount = 1 });
                break;
        }
    }
 

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Interactable")
        {
            GameObject interact = collision.gameObject;
            if (Input.GetKey(KeyCode.Q))
            {
                interact.GetComponent<InteractAction>().Use(interact, gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemworld = collision.GetComponent<ItemWorld>();
        if(itemworld != null)
        {
            inventory.Additem(itemworld.GetItem());
            itemworld.Destroyself();
        }
    }

    public void SetWeaponStats(int dmg, float range, int coms, float swingTime)
    {
        Weapondmg = dmg;
        attrange = range;
        hungercoms = coms;
        SwingTime = swingTime;
        attcircle.localScale = new Vector2((float)attrange, (float)attrange);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpos.position, attrange);
    }
    public void AddEquippedItem(Item.Itemtype type, int amt)
    {
        inventory.Additem(new Item { itemType = type, amount = amt });
    }
    public void Drop(Item.Itemtype type, int amt)
    {
        Vector3 direct = attackpos.position - transform.position;
        Vector3 droppos = attackpos.position + direct;
        inventory.DropItem(new Item { itemType = type, amount = amt }, droppos);
    }
}
