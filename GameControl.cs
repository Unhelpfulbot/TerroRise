using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public int CompletedPillar = 0;
    public int deathallowed;
    public GameObject stoneBlock;
    public GameObject Player;
    private Health health;
    void Start()
    {
        health = Player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.Deathcount >= deathallowed)
        {
            SceneManager.LoadScene(2);
        }
        if(CompletedPillar >= 3)
        {
            stoneBlock.SetActive(false);
        }
    }
}
