using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public CircleCollider2D cc;
    public Transform playerloc;
    public float DashCd;
    private float TimeDash;
    public int dmg;
    private Health playerhp;
    private Vector3 direct;
    private bool canDash;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canDash = true;
            playerloc = collision.transform;
            direct = playerloc.position - transform.position;
            direct.z = transform.position.z;
            playerhp = collision.GetComponent<Health>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canDash = false;
        }
    }
    private void Awake()
    {
        TimeDash = Time.time + DashCd;
    }
    private void Update()
    {
        if(TimeDash < Time.time)
        {
            if (canDash)
            {
                playerhp.TakenDamage(dmg);
                transform.position = playerloc.position + direct;
                TimeDash = Time.time + DashCd;
            }
        }
    }
}
