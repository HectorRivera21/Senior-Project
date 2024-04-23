using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHurtBox : MonoBehaviour
{
    // GameObject enemy;
    public float k_force;
    int e_health;
    SpriteRenderer sprite_e;
    Color currentColor;
    float blinking_red = 1f;
    bool is_hit = false;

    GuardianSfx guardian_sounds;

    // Start is called before the first frame update
    void Start()
    {
        e_health = gameObject.GetComponentInParent<check>().health;
        sprite_e = gameObject.GetComponentInParent<SpriteRenderer>();
        currentColor = sprite_e.color;
        guardian_sounds = GetComponentInParent<GuardianSfx>();
        // Debug.Log("Starting e_health " + e_health);
    }

    // Update is called once per frame
    void Update()
    {
        e_health = gameObject.GetComponentInParent<check>().health;

        if(is_hit == true && blinking_red >= 0){
            sprite_e.color = Color.red;
            blinking_red -= Time.deltaTime;
        }
        else if(blinking_red <= 0){
            is_hit = false;
            sprite_e.color = currentColor;
            blinking_red = 1f;
        }

    }

     private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log(other);
        if(other.tag == "PlayerHitBox"){
            guardian_sounds.GuardianHit();
            is_hit = true;
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
