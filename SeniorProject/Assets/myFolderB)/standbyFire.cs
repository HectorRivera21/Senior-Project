using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standbyFire : MonoBehaviour
{
    public int burnDamage = 1; 
    public float burnDuration = 10f;
    public float burnTickRate = 1f;

    private bool playerCollision = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            playerCollision = true;
            InvokeRepeating(nameof(ApplyBurnDamage), 0f, burnTickRate);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            playerCollision = false;
            CancelInvoke(nameof(ApplyBurnDamage)); 
        }
    }

    private void ApplyBurnDamage()
    {
        if (playerCollision)
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.ApplyBurnDamage(burnDamage);

            
            burnDuration -= burnTickRate;
            if (burnDuration <= 0f){
                playerCollision = false;
                CancelInvoke(nameof(ApplyBurnDamage));
            }
        }
    }
}

