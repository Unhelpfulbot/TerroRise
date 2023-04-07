using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public CircleCollider2D cc;
    public Rigidbody2D rb;
    public Transform tf;
    public Animator anim;
    public float moveSpeed;
    private float speed;
    public Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            return;
        }
        GameObject player = collision.gameObject;
        Transform playerpos = player.transform;
        Vector3 direction = playerpos.position - transform.position;
        movement = direction;
        speed = moveSpeed;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            return;
        }
        speed = 0;
    }
    void MoveMon(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));
    }
    private void FixedUpdate()
    {
        MoveMon(movement);
    }
}
