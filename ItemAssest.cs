using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssest : MonoBehaviour
{
    public static ItemAssest Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
    }
    public Transform Itemworldprefab;

    public Sprite GoldKeysprite;
    public Sprite SilverKeysprite;
    public Sprite Beefsprite;
    public Sprite Calamarisprite;
    public Sprite Fishsprite;
    public Sprite FortuneCookiesprite;
    public Sprite Octopussprite;
    public Sprite Onigirisprite;
    public Sprite Shrimpsprite;
    public Sprite Sushisprite;
    public Sprite Tealeafsprite;
    public Sprite Emptypotsprite;
    public Sprite Lifepotsprite;
    public Sprite Medpacksprite;
    public Sprite Milkpotsprite;
    public Sprite Axesprite;
    public Sprite Clubsprite;
    public Sprite Forksprite;
    public Sprite Hammersprite;
    public Sprite Lancesprite;
    public Sprite Raipersprite;
    public Sprite Sticksprite;
    public Sprite Swordsprite;
    public Sprite WHelmetsprite;
    public Sprite CHelmetsprite;
    public Sprite IHelmetsprite;
    public Sprite RHelmetsprite;
    public Sprite WChestsprite;
    public Sprite CChestsprite;
    public Sprite IChestsprite;
    public Sprite RChestsprite;
    public Sprite WLegsprite;
    public Sprite CLegsprite;
    public Sprite ILegsprite;
    public Sprite RLegsprite;
}
