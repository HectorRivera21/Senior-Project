using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f;
    public float dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    private void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        ProcressInputs();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <=0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime; 
        }

    }

    private void FixedUpdate()
    {



        Move();
    }

    void ProcressInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}