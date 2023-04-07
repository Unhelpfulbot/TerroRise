using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Transform spawn;

    public float maxHealth = 50;
    public float currentHealth;
    public float maxHunger = 10;
    public float currentHunger;
    public HealthBar healthBar;
    public HungerBar hungerBar;
    public Movement movement;

    public float HArmor;
    public float CArmor;
    public float LArmor;
    public float Armor = 0;

    public float Hungertick = 30f;
    public float Regentick = 15f;
    public float tick = 60f;

    public float Timer;
    public float Timer2;
    public float Timer3;

    public int Deathcount = 0;
    public Text Deathtext;
    void Start()
    {
        movement = GetComponent<Movement>();
        currentHunger = maxHunger;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        hungerBar.SetMaxHunger(maxHunger);
        Timer = Time.time;
        Timer2 = Time.time;
        Timer3 = Time.time + tick; 
    }
    private void Update()
    {
        Armor = HArmor + CArmor + LArmor;
        if(Timer3 < Time.time)
        {
            HungerLost(5);
            Timer3 = Time.time + tick;
        }
        if(currentHunger <= 0)
        {
            currentHunger = 0;
            if(Timer < Time.time)
            {
                TakenDamage(3);
                Timer = Time.time + Hungertick;
            }
        }
        if(currentHealth <= 0)
        {
            Deathcount++;
            Deathtext.text = Deathcount + "/10";
            movement.Dead = true;
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
            currentHunger = maxHunger;
            hungerBar.SetHunger(currentHunger);
            transform.position = spawn.position;
        }
        if(currentHealth < maxHealth)
        {
            if(currentHunger > 40)
            {
                if(Timer2 < Time.time)
                {
                    if(currentHealth + 2 > maxHealth)
                    {
                        currentHealth = maxHealth;
                        healthBar.SetHealth(currentHealth);
                    }
                    else
                    {
                        currentHealth += 2;
                        healthBar.SetHealth(currentHealth);
                    }
                    Timer2 = Time.time + Regentick;
                }
            }
        }
    }


    public void TakenDamage(int damage)
    {
        currentHealth -= (damage - Armor);
        healthBar.SetHealth(currentHealth);
    }
    public void HealthGain(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }
    public void HungerLost(int hunger)
    {
        currentHunger -= hunger;
        hungerBar.SetHunger(currentHunger);
    }
    public void HungerGain(int hunger)
    {
        currentHunger += hunger;
        hungerBar.SetHunger(currentHunger);
    }
    public void IncreaseMaxHealth(int health)
    {
        maxHealth += health;
        healthBar.SetMax(maxHealth);
    }
    public void DecreaseMaxHealth(int health)
    {
        maxHealth -= health;
        healthBar.SetMax(maxHealth);
        currentHealth -= health;
    }
   public void IncreaseMaxHunger(int hunger)
    {
        maxHunger += hunger;
        hungerBar.SetMax(maxHunger);
    }
    public void Killself()
    {
        currentHealth -= currentHealth;
    }
}
