using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombEnemy : MonoBehaviour
{

    public int explosionDamage = 20;

    public float explosionRadius = 5f;
    public float ignitionRange = 3f;
    public float explosionDelay = 10f;

    private bool playerNearby = false;
    private bool exploded = false;

    void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    void Update(){
        if (playerNearby && !exploded)
        {
            StartCoroutine(ExplodeAfterDelay());
        }
    }

    IEnumerator ExplodeAfterDelay(){
        exploded = true;
        yield return new WaitForSeconds(explosionDelay);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders){
            if (collider.CompareTag("Player")){
                PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(explosionDamage);
                }
            }
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}