using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    Grounded grounded;
    float moveInput;
    bool jump = false;

    public float jumpForce = 80f;
    public float moveForce = 40f;
    public float maxSpeed = 20f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        grounded = GetComponent<Grounded>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        jump |= Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        rigid.AddForce(moveForce * transform.right * moveInput);

        if (jump)
        {
            jump = false;
            if (grounded.IsGronudedForJump())
            {
                Debug.Log("Jumped");
                rigid.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);

            }
        }

        if (rigid.velocity.magnitude >= maxSpeed)
        {
            rigid.velocity = rigid.velocity.normalized * maxSpeed;
        }
    }
}
