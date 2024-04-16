using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float fireForce = 20.0f;

    [SerializeField] private AudioSource shootSfx;

    private float timer;
    private GameObject player;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

 
    void Update(){
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 10){
            timer += Time.deltaTime;

            if (timer > 2){
                timer = 0;
                shoot();
            }

        }

    }

    void shoot(){
        Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(bulletPos.up * fireForce, ForceMode2D.Impulse);
    }
}
