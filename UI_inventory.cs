using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotcontainer;
    private Transform itemSlotTemplate;
    private void Awake()
    {
        itemSlotcontainer = transform.Find("Itemslotcontainer");
        itemSlotTemplate = itemSlotcontainer.Find("ItemslotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChange += Inventory_OnItemChange;
        RefreshInventoryItems();
    }
    private void Inventory_OnItemChange(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotcontainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotcellsize = 40f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform ItemslotRecTransform = Instantiate(itemSlotTemplate, itemSlotcontainer).GetComponent<RectTransform>();
            ItemslotRecTransform.gameObject.SetActive(true);

            ItemslotRecTransform.anchoredPosition = new Vector2(x * itemSlotcellsize - 100, -y * itemSlotcellsize + 40);
            Image image = ItemslotRecTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            ItemslotRecTransform.GetComponent<OnClickItem>().item = item;
            Text text = ItemslotRecTransform.Find("Text").GetComponent<Text>();

            if (item.amount > 1)
            {
                text.text = item.amount.ToString();
            }
            else
            {
                text.text = " ";
            }
            x++;
            if(x > 5)
            {
                x = 0;
                y++;
            }
        }
    }
}
