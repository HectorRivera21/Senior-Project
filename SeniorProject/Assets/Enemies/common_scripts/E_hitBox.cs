using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_hitBox : MonoBehaviour
{
    Rigidbody2D p_rb;

    public float knockbackForce = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        p_rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Player Hitbox SGSGSFGS" + other);

        Collider2D collider = other.collider;

        Debug.Log(collider.name);
        // offset the collsion for knockback
        Vector2 direction = (collider.transform.position - transform.position).normalized;
        //knockback is in direcrtion
        Vector2 knockback = direction * knockbackForce; 
        Debug.Log("Knock back: " + knockback);

        p_rb.AddForce(knockback);
    }
}
