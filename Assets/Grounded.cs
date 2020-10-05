using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    float gravityStrength;
    Rigidbody2D rigid;

    public float isGroundedTolerance = .1f;
    private void Awake()
    {
        gravityStrength = Physics2D.gravity.magnitude;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RotateIfOnGround();
    }

    bool RotateIfOnGround()
    {
        RaycastHit2D hit = GetGround();
        if (hit)
        {
            Physics2D.gravity = -hit.normal.normalized * gravityStrength;
            rigid.SetRotation(Quaternion.LookRotation(transform.up, hit.normal));
            return true;
        }

        return false;
    }

    RaycastHit2D GetGround()
        {
            return Physics2D.Raycast(transform.position, Vector2.down, isGroundedTolerance);
        }
    }
