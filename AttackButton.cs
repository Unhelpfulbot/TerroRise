using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public GameObject boss;
    public float CD;
    public float Timer;

    void Awake()
    {
        Timer = Time.time + CD;     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.GetComponent<MonsterStat>().TakenDamage(20);
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if(Timer < Time.time)
        {
            gameObject.SetActive(false);
        }
    }
}
