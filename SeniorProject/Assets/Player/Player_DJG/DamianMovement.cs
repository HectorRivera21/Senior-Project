using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DamianMovement : MonoBehaviour
{
    SpawnE _spawnE;
    public float move_speed = 5f;
    public float teleport_distance = 2f;
    public float teleport_cooldown = 3f;
    private float teleport_active = 0;
    private Vector3 move_direction;
    private bool is_tp = false;
    public Rigidbody2D rb;

    void Start() {
        _spawnE = gameObject.GetComponent<SpawnE>(); 
    }

     void Update() {
        proccessInputs();
    //     if(Input.GetKeyUp(KeyCode.Space)){
    //         Debug.Log("KNOCK");
    //         rb.AddForce(transform.up * 100000f);
    //     }
    }
    void FixedUpdate() {

        teleport_active -= Time.deltaTime;

        // Check if the timer has reached zero
        if (teleport_active <= 0f && Input.GetKey(KeyCode.LeftShift))
        {
            // Timer has expired, perform actions here
            // Debug.Log("Timer has reached zero!");

            // Reset the timer for repeated use
            teleport_active = teleport_cooldown;
            TeleportPlayer();
        }

        move();
    }

    void proccessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        move_direction = new Vector3(moveX,moveY, -0.5f).normalized;
        // move_direction = new Vector2(moveX,moveY).normalized;

        // if(Input.GetKeyUp(KeyCode.Z)){
        //     _spawnE.SpawnSlime();
        // }
        // if(Input.GetKeyUp(KeyCode.X)){
        //     _spawnE.SpawnGaurdain();
        // }
    }

    void move(){
        rb.velocity = new Vector2(move_direction.x * move_speed, move_direction.y * move_speed);
        
    }

    void TeleportPlayer()
    {
        // Get the current player position and rotation
        Vector3 currentPosition = transform.position;

        // Calculate the teleport destination
        Vector3 teleportDestination = currentPosition + move_direction * teleport_distance;
        transform.position = new Vector3(transform.position.x,transform.position.y, -0.5f);

        // Teleport the player to the destination
        transform.position = teleportDestination;

        

        // Debug.Log("Player teleported to: " + teleportDestination);
    }
}