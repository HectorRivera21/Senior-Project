using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force = 30f;
    public float k_force = 500000;
    public float dead_timer = 2.0f;
    private GameObject Enemy;
    private GameObject player;

    public int damage;
    // Start is called before the first frame update
    public Vector2 moveDirection; // Direction of bullet movement
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        // rb.velocity *=  force;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * force * Time.deltaTime);
        dead_timer -= Time.deltaTime;
        if(dead_timer < 0){
            Debug.Log("BULLET DIED");
            Destroy(gameObject);
        }
        // transform.Translate(move* speed * Time.deltaTime);
    }

    // Set the initial movement direction
    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Enemy = other.transform.parent.gameObject;
        if(other.tag != "Player" ){
        
            if(other.tag == "Enemy"){
                Debug.Log("BULLET HIT : " + other.name);
                Enemy = other.transform.parent.gameObject;
                AddingKnockBack();
                Destroy(gameObject);
            }
            else if(other.tag == "E_HitBox"){
                 Debug.Log("BULLET HIT A HITBOX: " + other.name);
                Destroy(gameObject);
            }
        }
    }

    private void AddingKnockBack(){
        Enemy.GetComponent<check>().health -= damage;
      
    }

}
