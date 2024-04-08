using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 10f;        
    public int damage = 10;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            enemyHealth enemyHealth = collision.GetComponent<enemyHealth>();

            if (enemyHealth != null) {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

}