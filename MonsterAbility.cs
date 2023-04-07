using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAbility : MonoBehaviour
{
    public CircleCollider2D cc;
    public float TimeCastCd;
    public float TimeCastTime;
    public float TimeCastRestrict;
    public float TimeCastCd2;
    public float TimeCastTime2;
    public float TimeCastRestrict2;
    public bool Inrange = false;

    public GameObject ProjectileSpell;
    public bool Spell1;
    public GameObject PlacementSpell;
    public bool Spell2;
    private void Awake()
    {
        TimeCastTime = Time.time + TimeCastRestrict;
        TimeCastTime2 = Time.time + TimeCastRestrict2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inrange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inrange = false;
        }
    }
    void Update()
    {
        if (Inrange) {
            if (Spell1) 
            {
                if (Time.time > TimeCastTime)
                {
                    GameObject Spells = Instantiate(ProjectileSpell, transform.position, Quaternion.identity);
                    Spells.GetComponent<ItemMovement>().direct = gameObject.GetComponent<MonsterMovement>().movement;
                    TimeCastTime = Time.time + TimeCastCd;
                }
            }
            if (Spell2)
            {
                if (Time.time > TimeCastTime2)
                {
                    Instantiate(PlacementSpell, transform.position, Quaternion.identity);
                    TimeCastTime2 = Time.time + TimeCastCd2;
                }
            }
        }
    }
}
