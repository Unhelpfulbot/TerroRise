using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   Rigidbody2D rb;
   Animator anim;
   public float moveSpeed = 5f;
   public Transform attpos;
   Vector2 movement;
   Vector2 direct;
   Vector2 attdirect;
   public bool Hit;
   public bool Dead;
   public bool canMove = true;

    private float HitCD = 1f;
    private float HitTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attdirect = attpos.position;
        HitTime = Time.time;
    }

    void Update()
    {
        if (Dead)
        {
            attdirect.x = transform.position.x;
            attdirect.y = transform.position.y;
            Dead = false;
        }
        if (!canMove)
        {
            return;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        if (movement.x > 0.1)
        {
            anim.SetInteger("Direct", 2);
            attdirect.x = transform.position.x + 0.7f;
            attdirect.y = transform.position.y;
            anim.SetInteger("Attack", 0);
        }
        else if (movement.x < -0.1)
        {
            anim.SetInteger("Direct", 3);
            attdirect.x = transform.position.x - 0.7f;
            attdirect.y = transform.position.y;
            anim.SetInteger("Attack", 0);
        }
        else if (movement.y > 0.1)
        {
            anim.SetInteger("Direct", 1);
            attdirect.x = transform.position.x;
            attdirect.y = transform.position.y + 0.7f;
            anim.SetInteger("Attack", 0);
        }
        else if (movement.y < -0.1)
        {
            anim.SetInteger("Direct", 0);
            attdirect.x = transform.position.x;
            attdirect.y = transform.position.y - 0.7f;
            anim.SetInteger("Attack", 0);
        }
        attpos.position = attdirect;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Monster")
        {
            return;
        }
        GameObject monster = collision.gameObject;
        Transform monpos = monster.transform;
        Health hp = GetComponent<Health>();
        Vector3 direction = transform.position - monpos.position;
        direct = direction;
        Hit = true;
        hp.TakenDamage(monster.GetComponent<MonsterStat>().AttDmg);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Hit)
        {
            if (Time.time >= HitTime)
            {
                GameObject monster = collision.gameObject;
                Health hp = GetComponent<Health>();
                hp.TakenDamage(monster.GetComponent<MonsterStat>().AttDmg);
                HitTime = Time.time + HitCD;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Monster")
        {
            return;
        }
        Hit = false;
    }
    void MovePlayer(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * 0.5f));
        attdirect += direction * 0.5f;
        attpos.position = attdirect;
        anim.SetInteger("Attack", 0);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * moveSpeed * Time.fixedDeltaTime));
        if (Hit)
        {
            MovePlayer(direct);
        }
    }
}
