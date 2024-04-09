using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyChase : MonoBehaviour
{
    public Transform playerTransform;
    public float chaseRadius = 3f;
    public float moveSpeed = 1f;
    public float damageAmount = 5f;

    private bool isChasing = false;

    void Start(){
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform;   
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) <= chaseRadius){
            isChasing = true;
        }
        else{
            isChasing = false;
        }

        if (isChasing){
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null){
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}