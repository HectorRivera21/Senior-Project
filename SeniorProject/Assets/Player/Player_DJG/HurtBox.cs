using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    GameObject Enemey;

    bool can_be_damage = false;
    float can_be_damage_time = 1;
    Rigidbody2D my_rb;
    

    public PlayerAttr player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerAttr>();
        my_rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
        can_be_damage_time -= Time.deltaTime;
        if(can_be_damage_time < 0 && can_be_damage == false){
           can_be_damage = true;
        }   
    }



    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log(other);
        if(other.name == "HitBox" && can_be_damage == true){
            Enemey = other.transform.parent.gameObject;
            Debug.Log(Enemey.name + " The Enemey object");
            int damage = other.GetComponentInParent<check>().me.damage;
            // Debug.Log(damage);
            // Debug.Log(player.health - damage);

            player.current_health -= damage;
        
            if(player.current_health < 0){
                Debug.Log("DESTROYED PLAYER");
                Destroy(player.gameObject);
            }

            Debug.Log("Player Health " + player.current_health);
            can_be_damage = false;
            can_be_damage_time = 1;

            Vector2 direction = (transform.position- Enemey.transform.position).normalized;
            my_rb.AddForce(direction * 1000000f);
        }
        else if(other.tag == "E_HitBox" && can_be_damage == true){
            // player.current_health -= other.GetComponent<EnemyBullet>().damage;
            if(player.current_health < 0){
                Debug.Log("DESTROYED PLAYER");
                Destroy(player.gameObject);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        Debug.Log("TESTING COLLODDD");
    }

}
