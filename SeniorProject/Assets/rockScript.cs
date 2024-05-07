using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockScript : MonoBehaviour
{
    public float gravityScale = 1f; // Adjust gravity scale if needed

    private void Start() {
        ApplyGravity();
    }

    private void ApplyGravity() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) {
            rb.gravityScale = gravityScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
