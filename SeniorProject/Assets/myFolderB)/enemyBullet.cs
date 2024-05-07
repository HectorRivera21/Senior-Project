using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 10f;
    private Vector3 targetPosition;
    private float timer;
    public int damage = 10;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        Vector3 direction = targetPosition - transform.position;
        rb.velocity = direction.normalized * speed;

        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
    void Update() {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }
}