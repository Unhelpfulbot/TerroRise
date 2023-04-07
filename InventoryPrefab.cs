using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPrefab : MonoBehaviour
{
    public GameObject prefabitem;
    Transform prefab;
    Item item;
    public Transform prefabimg;
    public Transform prefabcount;
    private void Start()
    {
        prefab = prefabitem.GetComponent<Transform>();
        prefabimg = prefab.Find("Item");
        prefabcount = prefab.Find("Count");
    }
    public void SetImage()
    {
        prefabimg.GetComponent<Image>().sprite = item.GetSprite();
    }
    public void SetCount(int count)
    {
        prefabcount.GetComponent<Text>().text = count.ToString();
    }
}
