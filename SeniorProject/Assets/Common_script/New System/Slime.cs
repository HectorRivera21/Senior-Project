using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
   GameObject player;
   public float damage = 1;
   public float knockbackForce = 100f;
   public float moveSpeed = 100f;
   Rigidbody2D rb;

   DamageableCharacter d_character;
   void Start() {
      player = GameObject.FindWithTag("Player");
      d_character = GetComponent<DamageableCharacter>();
      rb = GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate() {
      if(d_character.Targetable){
         Vector2 dirction = (player.transform.position -transform.position).normalized;

         // Vector2 dirction = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

         rb.AddForce(dirction * moveSpeed * Time.deltaTime);
      }
   }
   void OnCollisionEnter2D(Collision2D other) {
      Collider2D collider = other.collider;
      IDamageable damageable = collider.GetComponent<IDamageable>();

      if(damageable != null){
         Debug.Log(collider.name);
         // offset the collsion for knockback
         Vector2 direction = (collider.transform.position - transform.position).normalized;
         //knockback is in direcrtion
         Vector2 knockback = direction * knockbackForce; 

         damageable.OnHit(damage, knockback);

      }
   }
}
