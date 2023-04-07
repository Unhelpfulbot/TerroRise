using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
   public GameObject teleportpos;
   public bool NonActive;
   public bool Mission;
    public GameObject blockade;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform playerpos = collision.gameObject.transform;
            playerpos.position = teleportpos.transform.position;
        }
        if (NonActive)
        {
            gameObject.SetActive(false);
        }
        if (Mission)
        {
            blockade.SetActive(false);
        }
    }
}
