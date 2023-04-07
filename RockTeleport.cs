using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTeleport : MonoBehaviour
{
    [SerializeField] Transform droploc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock"))
        {
            collision.transform.position = droploc.position;
        }
    }
}

