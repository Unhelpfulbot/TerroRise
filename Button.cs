using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject blockade;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock") || collision.CompareTag("Player"))
        {
            blockade.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock") || collision.CompareTag("Player"))
        {
            blockade.SetActive(true);
        }
    }
}
