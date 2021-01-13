using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    float last_horizontal = 0f;
    float last_vertical = 0f;
    float cur_horizontal = 0f;
    float cur_vertical = 0f;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        

        cur_horizontal = movement.x;
        cur_vertical = movement.y;


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        if(cur_horizontal != 0.0f || cur_vertical != 0.0f)
        {
            last_horizontal = cur_horizontal;
            last_vertical = cur_vertical;
        }
        animator.SetFloat("IdleHor", last_horizontal);
        animator.SetFloat("IdleVer", last_vertical);
    }

    void FixedUpdate()
    {
        if (movement.x != 0.0f && movement.y != 0.0f)
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime /1.414f);    
        else
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
