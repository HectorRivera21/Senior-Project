using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float damage = 10f;

    public healthBarSystem healthBar;

    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth((int)maxHealth);
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0f);
        healthBar.SetHealth((int)currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ApplyBurnDamage (int burnDamage)
    {
        Debug.Log("help me im burning");
        currentHealth -= burnDamage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemies"))
        {
            Debug.Log("Enemy Collission.");
            TakeDamage(damage);
        }
    }

    void Die() {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}
