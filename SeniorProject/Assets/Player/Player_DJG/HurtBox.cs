using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    GameObject Enemey;
    public HealthBar healthBar;
    public GameManagerScript gameManager;
    public GameObject MapGeneration; 

    bool can_be_damage = false;
    float can_be_damage_time = 1;
    Rigidbody2D my_rb;

    SpriteRenderer sprite_player;
    float blinking_red = 1f;
    bool is_hit = false;

    PlayerSfx player_sounds;
    

    public PlayerAttr player;
    // Start is called before the first frame update
    void Start()
    {
        sprite_player = gameObject.GetComponentInParent<SpriteRenderer>();
        player = gameObject.GetComponentInParent<PlayerAttr>();
        my_rb = gameObject.GetComponentInParent<Rigidbody2D>();
        player_sounds = GetComponentInParent<PlayerSfx>();
        Time.timeScale = 1f;
    }
    

    // Update is called once per frame
    void Update()
    {
        can_be_damage_time -= Time.deltaTime;
        if(can_be_damage_time < 0 && can_be_damage == false){
           can_be_damage = true;
        }   

        if(is_hit == true && blinking_red >= 0){
            sprite_player.color = Color.red;
            blinking_red -= Time.deltaTime;
        }
        else if(blinking_red <= 0){
            is_hit = false;
            sprite_player.color = Color.white;
            blinking_red = 1f;
        }


    }



    private void OnTriggerEnter2D(Collider2D other) {

        // Debug.Log(other);
        if(other.name == "HitBox" && can_be_damage == true){
            player_sounds.PlayerHit();
            is_hit = true;
            Enemey = other.transform.parent.gameObject;
            Debug.Log(Enemey.name + " The Enemey object");
            int damage = other.GetComponentInParent<check>().me.damage;
            // Debug.Log(damage);
            // Debug.Log(player.health - damage);

            healthBar.SetMaxHealth(player.current_health);
            player.current_health -= damage;
            healthBar.SetHealth(player.current_health);
        
            if(player.current_health < 0){
                Debug.Log("DESTROYED PLAYER");
                Time.timeScale = 0f;
                //player.GetComponent<Movement>().enabled = false;
                player_sounds.PlayerDeath();
                gameManager.gameOver();
                // Destroy(player.gameObject);
                

            }

            Debug.Log("Player Health " + player.current_health);
            can_be_damage = false;
            can_be_damage_time = 1;

            Vector2 direction = (transform.position- Enemey.transform.position).normalized;
            my_rb.AddForce(direction * 300000f);
        }
        else if(other.tag == "E_HitBox" && can_be_damage == true){
            player_sounds.PlayerHit();
            player_sounds.PlayerHit();
            is_hit = true;
            // player.current_health -= other.GetComponent<EnemyBullet>().damage;
        
            if(player.current_health < 0){
                Debug.Log("DESTROYED PLAYER");
                Time.timeScale = 0f;
                //player.GetComponent<Movement>().enabled = false;
                player_sounds.PlayerDeath();
                gameManager.gameOver();
                // Destroy(player.gameObject);

            }
        }
        // is_hit = true;
    }

    private void OnCollisionStay2D(Collision2D other) {
        Debug.Log("TESTING COLLODDD");
    }

}
