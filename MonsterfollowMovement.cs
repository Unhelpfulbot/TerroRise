using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterfollowMovement : MonoBehaviour
{
    public Animator anim;
    public float MoveSpeed;
    [SerializeField] private GameObject[] waypoints;
    private int currentIndex = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentIndex].transform.position, transform.position) < 0.1f)
        {
            currentIndex++;
            anim.SetFloat("Direction", -1);
            if(currentIndex >= waypoints.Length)
            {
                currentIndex = 0;
                anim.SetFloat("Direction", 1);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex].transform.position, MoveSpeed * Time.deltaTime);
    }
}
