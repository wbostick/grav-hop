using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    bool moveForward = false;

    public float moveForce = 5f;
    public float maxSpeed = 5f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveForward = Input.GetButton("Forward");
    }

    private void FixedUpdate()
    {
        if (moveForward)
        {
            rigid.AddForce(moveForce * transform.right);
        }

        if (rigid.velocity.magnitude >= maxSpeed)
        {
            rigid.velocity = rigid.velocity.normalized * maxSpeed;
        }
    }
}
