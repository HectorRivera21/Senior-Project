using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossActions : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public int maxHealth = 500;
    public float chaseSpeed = 2f;
    public float attackCooldown = 15f;
    public int collisionDamage = 20;

    public float stopDistance = 2f;

    private int currentHealth;
    private bool bigAttack = false;
    //private Animator animator;

    private void Start() {
        //animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        StartCoroutine(InitialDelayBeforeAttack());
    }

    private IEnumerator InitialDelayBeforeAttack() {
        yield return new WaitForSeconds(6f); 
        StartCoroutine(AttackRoutine());
    }

    private void Update() {
        //testing health and 200 hp
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
        }
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Vector3 playerDirection = (playerObject.transform.position - transform.position).normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, playerObject.transform.position);

            if (distanceToPlayer > stopDistance) {
                transform.position += playerDirection * chaseSpeed * Time.deltaTime;
            }
        }
    }

    private IEnumerator AttackRoutine() 
    {
        int bigAttackCount = 0;

        while (true)
        {
            if (!bigAttack)
            {
                if (bigAttackCount < 2) {
                    ShootBullet();
                    ShootBullet();
                    yield return new WaitForSeconds(1f);
                    ShootBullet();
                    ShootBullet();

                    bigAttackCount++;
                }
                // delays
                else {
                    yield return new WaitForSeconds(5f);
                    DashTowardsPlayer(); 
                    yield return new WaitForSeconds(3f); 
                    SendRandomBullets();
                    yield return new WaitForSeconds(5f);
                    bigAttackCount = 0;
                }
            }
        }
    }

    private void DashTowardsPlayer() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Vector3 direction = (playerObject.transform.position - transform.position).normalized;
            float dashDistance = 5f; 
            transform.position += direction * dashDistance;
        }
    }

    private void SendRandomBullets() {
        for (int i = 0; i < 360; i += 10)
        {
            float randomAngle = Random.Range(0f, 360f);
            Vector3 spawnPosition = firePoint.position + Quaternion.Euler(0, 0, randomAngle) * Vector3.right * 2f;
            Instantiate(bulletPrefab, spawnPosition, Quaternion.Euler(0, 0, randomAngle));
        }
    }

    private void ShootBullet() {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }


    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else if (currentHealth <= 200){
            chaseSpeed *= 1.5f;
            attackCooldown /= 2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null) {
                playerHealth.TakeDamage(collisionDamage);
            }
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}