using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DamianMovement : MonoBehaviour
{
    public float move_speed = 5f;
    public float teleport_distance = 5f;
    public float teleport_cooldown = 3f;
    private float teleport_active = 0;
    private Vector2 move_direction;
    private bool is_tp = false;
    public Rigidbody2D rb;

     void Update() {
        proccessInputs();
    }
    void FixedUpdate() {

        teleport_active -= Time.deltaTime;

        // Check if the timer has reached zero
        if (teleport_active <= 0f && Input.GetKey(KeyCode.LeftShift))
        {
            // Timer has expired, perform actions here
            Debug.Log("Timer has reached zero!");

            // Reset the timer for repeated use
            teleport_active = teleport_cooldown;
            TeleportPlayer();
        }

        move();
    }

    void proccessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        move_direction = new Vector2(moveX,moveY).normalized;
        // move_direction = new Vector2(moveX,moveY).normalized;
    }

    void move(){
        rb.velocity = new Vector2(move_direction.x * move_speed, move_direction.y * move_speed);
        
    }

    void TeleportPlayer()
    {
        // Get the current player position and rotation
        Vector2 currentPosition = transform.position;

        // Calculate the teleport destination
        Vector2 teleportDestination = currentPosition + move_direction * teleport_distance;

        // Teleport the player to the destination
        transform.position = teleportDestination;

        

        Debug.Log("Player teleported to: " + teleportDestination);
    }
}