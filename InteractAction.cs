using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractAction : MonoBehaviour
{
    public Image itemImage;
    public Text itemText;
    public Item item;
    public Sprite objectsprite;
    public GameObject bossPrefab;
    public Transform bossRoom;
    public Transform bossSpawn;
    public GameObject portal;

    public string Description;
    public GameObject openchest;
    public GameObject opendoor;
    public GameObject discoverchat;
    public UI_inventory invent;
    public GameObject rock;
    [SerializeField] Transform teleportloc;

    Inventory inventorys;
    private void Start()
    {
        invent = GetComponent<UI_inventory>();
    }
    public enum objects
    {
        Tree,
        Chest,
        NPC,
        SPillars,
        MPillars,
        LPillars,
        Door,
        Door2,
        Teleport,
        ResetRock,
        Trader,
        Seller,
        Fighter,
        Fighter2,
        Trader2,
        Trader3,
    }
    public objects Object;
 public void Use(GameObject obj, GameObject player)
    {
        switch (Object)
        {
            case objects.Tree:
                discoverchat.SetActive(true);
                itemImage.sprite = item.GetSprite();
                itemText.text = Description;
                ItemWorld.SpawnItem(transform.position, item);
                gameObject.SetActive(false);
                player.GetComponent<PlayerAction>().GoldKey = true;
                break;
            case objects.Chest:
                obj.SetActive(false);
                Instantiate(openchest, transform.position, Quaternion.identity);
                ItemWorld.SpawnItem(transform.position, item);
                break;
            case objects.NPC:
                break;
            case objects.SPillars:
                player.transform.position = bossRoom.position;
                bossPrefab.SetActive(true);
                gameObject.SetActive(false);
                portal.SetActive(true);
                break;
            case objects.MPillars:
                player.transform.position = bossRoom.position;
                bossPrefab.SetActive(true);
                gameObject.SetActive(false);
                portal.SetActive(true);
                break;
            case objects.LPillars:
                player.transform.position = bossRoom.position;
                bossPrefab.SetActive(true);
                gameObject.SetActive(false);
                portal.SetActive(true);
                break;
            case objects.Door:
                if (player.GetComponent<PlayerAction>().GoldKey)
                {
                    gameObject.SetActive(false);
                    Instantiate(opendoor, transform.position, Quaternion.identity);
                    player.GetComponent<PlayerAction>().GoldKey = false;
                    player.GetComponent<PlayerAction>().inventory.RemoveItem(new Item { itemType = Item.Itemtype.GoldKey, amount = 1 });
                }
                break;
            case objects.Door2:
                if (player.GetComponent<PlayerAction>().SilverKey)
                {
                    gameObject.SetActive(false);
                    Instantiate(opendoor, transform.position, Quaternion.identity);
                    player.GetComponent<PlayerAction>().SilverKey = false;
                    player.GetComponent<PlayerAction>().inventory.RemoveItem(new Item { itemType = Item.Itemtype.GoldKey, amount = 1 });
                }
                break;
            case objects.Trader:
                player.GetComponent<PlayerAction>().inventory.Additem(new Item { itemType = Item.Itemtype.Lifepot, amount = 3});
                gameObject.SetActive(false);
                break;
            case objects.Teleport:
                player.transform.position = teleportloc.position;
                break;
            case objects.ResetRock:
                rock.transform.position = teleportloc.position;
                discoverchat.SetActive(true);
                itemImage.sprite = objectsprite;
                itemText.text = Description;
                break;
            case objects.Fighter:
                discoverchat.SetActive(true);
                itemImage.sprite = objectsprite;
                itemText.text = Description;
                gameObject.SetActive(false);
                Instantiate(bossPrefab,transform.position, Quaternion.identity);
                break;
            case objects.Fighter2:
                discoverchat.SetActive(true);
                itemImage.sprite = objectsprite;
                itemText.text = Description;
                gameObject.SetActive(false);
                bossPrefab.SetActive(true);
                break;
            case objects.Trader2:
                player.GetComponent<PlayerAction>().inventory.Additem(new Item { itemType = Item.Itemtype.Beef, amount = 5 });
                gameObject.SetActive(false);
                break;
            case objects.Trader3:
                player.GetComponent<PlayerAction>().inventory.Additem(new Item { itemType = Item.Itemtype.Calamari, amount = 3 });
                gameObject.SetActive(false);
                break;
        }
    }
}
