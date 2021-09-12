using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private int currentHealth;
    private int maxHealth;

    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField] HealthBar healthBar;

    //Constructor
    public HealthSystem(int maxHealth, HealthBar healthBar)
    {
        this.maxHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        this.healthBar = healthBar;
        currentHealth = maxHealth;
        
    }

    public int GetHealth()
    {
        return this.currentHealth;
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        //Updates the health bar
        healthBar.SetHealth(currentHealth);
    }
}
