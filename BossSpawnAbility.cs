using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnAbility : MonoBehaviour
{
    [SerializeField] GameObject[] attacks;
    [SerializeField] Transform[] spawns;
    [SerializeField] GameObject knight;

    [SerializeField] float CD;
    [SerializeField] float CastTime;
    [SerializeField] float CD2;
    [SerializeField] float CastTime2;

    void Awake()
    {
        CastTime = Time.time + CD;
        CastTime2 = Time.time + CD2;
    }

    // Update is called once per frame
    void Update()
    {
        if(CastTime < Time.time)
        {
            int num = Random.Range(0, attacks.Length);
            attacks[num].SetActive(true);
            CastTime = Time.time + CD;
        }
        if(CastTime2 < Time.time)
        {
            int num = Random.Range(0,spawns.Length);
            Instantiate(knight,spawns[num]);
            CastTime2 = Time.time + CD2;
        }
    }
}
