using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItem(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssest.Instance.Itemworldprefab, position, Quaternion.identity);
        ItemWorld itemworld = transform.GetComponent<ItemWorld>();
        itemworld.SetItem(item);
        return itemworld;
    }
    private Item item;
    private SpriteRenderer sr;
    private TextMeshPro textmesh;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        textmesh = transform.Find("Text").GetComponent<TextMeshPro>();
    }
    public void SetItem(Item item)
    {
        this.item = item;
        sr.sprite = item.GetSprite();
        if (item.amount > 1)
        {
            textmesh.SetText(item.amount.ToString());
        }
        else
        {
            textmesh.SetText("");
        }
    }
    public Item GetItem()
    {
        return item;
    }
    public void Destroyself()
    {
        Destroy(gameObject);
    }
}
