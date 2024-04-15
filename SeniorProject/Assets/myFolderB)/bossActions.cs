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

    public float stopDistance = 2f;

    private int currentHealth;
    private bool bigAttack = false;

    //private Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        StartCoroutine(AttackRoutine());
    }

    private void Update(){

        //testing health and 200 hp
        if (Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(10);
        }

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Vector3 playerDirection = (playerObject.transform.position - transform.position).normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, playerObject.transform.position);

            if (distanceToPlayer > stopDistance){
                transform.position += playerDirection * chaseSpeed * Time.deltaTime;
            }
        }
    }


    private IEnumerator AttackRoutine(){

        int bigAttackCount = 0;

        while (true){
            yield return new WaitForSeconds(attackCooldown);

            if (!bigAttack){
                ShootBullet();
                yield return new WaitForSeconds(1f);
                ShootBullet();
            }
            else{
                if (bigAttackCount < 2) {
                    //this is suppose to send random bullets but it aint working
                    for (int i = 0; i < 360; i += 10){
                        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, i));
                    }

                    bigAttackCount++;
                }
                else { 
                    yield return new WaitForSeconds(10f);
                }
            }
        }
    }

    private void ShootBullet(){
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    public void TakeDamage(int damage){
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

    private void Die(){
        Destroy(gameObject);
    }
}