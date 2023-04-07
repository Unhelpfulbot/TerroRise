using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    public GameObject[] spawnitem;
    bool CanSpawn;
    public float SpawnTime;
    [SerializeField] float spawnCD;
    private int spawnCount;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanSpawn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanSpawn = false;
        }
    }
    private void Start()
    {
        SpawnTime = Time.time;
        spawnCount = spawnitem.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSpawn)
        {
            if(SpawnTime < Time.time)
            {
                Instantiate(spawnitem[Random.Range(0,spawnCount)], transform);
                SpawnTime = Time.time + spawnCD;
            }
        }
    }
}
