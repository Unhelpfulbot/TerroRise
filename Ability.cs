using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float TimeCastCd;
    public float TimeCastTime;
    public float TimeCastRestrict;
    public float TimeCastCd2;
    public float TimeCastTime2;
    public float TimeCastRestrict2;
    public float TimeCastCd3;
    public float TimeCastTime3;
    public float TimeCastRestrict3;

    public GameObject Spell1;
    public bool Have1;
    public GameObject Spell2;
    public bool Have2;
    public GameObject Spell3;
    public bool Have3;
    private void Awake()
    {
        TimeCastTime = Time.time + TimeCastRestrict;
        TimeCastTime2 = Time.time + TimeCastRestrict2;
        TimeCastTime3 = Time.time + TimeCastRestrict3;
    }
    void Update()
    {
        Vector3 direction = gameObject.GetComponent<BossMovement>().movement;
        if (Have1)
        {
            if (Time.time > TimeCastTime)
            {
                GameObject Spells = Instantiate(Spell1, transform.position, Quaternion.identity);
                Spells.GetComponent<ItemMovement>().direct = direction;
                TimeCastTime = Time.time + TimeCastCd;
            }
        }
        if (Have2)
        {
            if (Time.time > TimeCastTime2)
            {
                Instantiate(Spell2, transform.position, Quaternion.identity);
                TimeCastTime2 = Time.time + TimeCastCd2;
            }
        }
        if (Have3)
        {
            if (Time.time > TimeCastTime3)
            {
                Instantiate(Spell3, transform.position + direction * 1 / 2, Quaternion.identity);
                TimeCastTime3 = Time.time + TimeCastCd3;
            }
        }
    }
}
