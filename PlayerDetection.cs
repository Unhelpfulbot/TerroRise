using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private CircleCollider2D cc;
    public GameObject Spawn;
    bool Hidden = true;
    public bool Inpos;
    // Start is called before the first frame update
    private void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Hidden)
            {
                if (Inpos)
                {
                    Spawn.SetActive(true);
                }
                else
                {
                    Transform position = collision.transform;
                    Spawn.SetActive(true);
                    Spawn.transform.position = position.position;
                }
                Hidden = false;
            }
        }
    }
}
