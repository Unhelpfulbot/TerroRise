using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireblast : MonoBehaviour
{
    public float disappearTime;
    float TimeDis;
    public float tick;
    float TickTime;
    public int damage;
    void Awake()
    {
        TimeDis = Time.time + disappearTime;
        TickTime = Time.time;
    }
    private void FixedUpdate()
    {
        if (Time.time > TimeDis)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            if (Time.time > TickTime)
            {
                TickTime = Time.time + tick;
                player.GetComponent<Health>().TakenDamage(damage);
            }
        }
    }
}
