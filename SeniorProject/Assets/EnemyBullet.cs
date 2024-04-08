using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBullet : MonoBehaviour
{
    // public float speed;
    private Transform target;
    // private Vector2 move;
    private Rigidbody2D rb;
    public float force = 15f;
    public float k_force = 500000;
    public float dead_timer = 2.0f;
    private GameObject player;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 dir = target.transform.position - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;
    }
    // Update is called once per frame
    void Update()
    {
        dead_timer -= Time.deltaTime;
        if(dead_timer < 0){
            Destroy(gameObject);
        }
        // transform.Translate(move* speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            // Debug.Log(other.name);
            AddingKnockBack();
            Destroy(gameObject);
        }
        else if(other.tag == "PlayerHitBox"){
            Destroy(gameObject);
        }
    }
    private void AddingKnockBack(){
        // offset the collsion for knockback
        Vector2 direction = (player.transform.position - transform.position).normalized;
        //knockback is in direcrtion
        Vector2 knockback = direction * k_force; 
        //Debug.Log("DIRECTION: " + direction + " Player current heaalth: " + player.GetComponent<PlayerAttr>().current_health);

        player.GetComponent<Rigidbody2D>().AddForce(knockback);

        player.GetComponentInChildren<HurtBox>().healthBar.SetMaxHealth(player.GetComponent<PlayerAttr>().current_health);
        player.GetComponent<PlayerAttr>().current_health -= damage;
        Debug.Log("PLAYERS HEALTH"+ player.GetComponent<PlayerAttr>().current_health);
        player.GetComponentInChildren<HurtBox>().healthBar.SetHealth(player.GetComponent<PlayerAttr>().current_health);
    }
}