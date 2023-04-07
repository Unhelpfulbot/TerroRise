using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    [SerializeField] public int AttDmg;
    [SerializeField] public int maxHealth;

    public Item item;
    public bool Boss;
    public int currentHealth;
    public int RegenAmt;
    public float RegenSec = 10f;
    public float RegenTime;
    public HealthBar healthBar;

    public GameObject nextobjective;
    public GameObject removeblock;
    public GameObject portal;
    public GameObject portalToBoss;
    public GameObject completedobjective;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        RegenTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            ItemWorld.SpawnItem(transform.position, item);
            if (Boss)
            {
                nextobjective.SetActive(true);
                portal.SetActive(true);
                completedobjective.SetActive(true);
                portalToBoss.SetActive(false);
                removeblock.SetActive(false);
            }
        }
        if (Boss)
        {
            if(currentHealth < maxHealth)
            {
                if(Time.time > RegenTime)
                {
                    currentHealth += RegenAmt;
                    if(currentHealth > maxHealth)
                    {
                        int differ = currentHealth - maxHealth;
                        currentHealth = currentHealth - differ;
                    }
                    healthBar.SetHealth(currentHealth);
                    RegenTime = Time.time + RegenSec;
                }
            }
        }
    }
    public void TakenDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}

