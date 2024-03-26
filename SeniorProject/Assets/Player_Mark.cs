using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mark : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public GameManagerScript gameManager;
    private bool isDead; 

    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
        }
    }
}
