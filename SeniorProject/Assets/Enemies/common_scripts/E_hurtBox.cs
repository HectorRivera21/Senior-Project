using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_hurtBox : MonoBehaviour
{
    // GameObject enemy;
    public float k_force;
    int e_health;
    // Start is called before the first frame update
    void Start()
    {
        e_health = gameObject.GetComponentInParent<check>().health;
        // Debug.Log("Starting e_health " + e_health);
    }

    // Update is called once per frame
    void Update()
    {
        e_health = gameObject.GetComponentInParent<check>().health;
    }

     private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log(other);
        if(other.tag == "PlayerHitBox"){
            int damage = other.GetComponentInParent<PlayerAttr>().damage;
            gameObject.GetComponentInParent<check>().e_damage(damage);
            Debug.Log(other.name);
            Debug.Log("Enemey " + e_health);
            AddingKnockBack(other.gameObject);
        }
    }


    // fix knockback on enemies
    private void AddingKnockBack(GameObject enemy){
        // offset the collsion for knockback
        Vector2 direction = (transform.position - enemy.transform.position).normalized;
        //knockback is in direcrtion
        Vector2 knockback = direction * k_force; 
        // Debug.Log("DIRECTION: " + direction);

        gameObject.GetComponentInParent<Rigidbody2D>().AddForce(knockback);
    }
}
