using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    float gravityStrength;
    Rigidbody2D rigid;
    public Transform groundCheckEndpoint;

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
        if (hit.collider)
        {
            Physics2D.gravity = -hit.normal.normalized * gravityStrength;
            rigid.SetRotation(Quaternion.LookRotation(Vector3.forward, hit.normal.normalized));
            return true;
        }
        else
        {
            return false;
        }

    }

    RaycastHit2D GetGround()
    {
        RaycastHit2D[] results = new RaycastHit2D[2];
        Vector2 direction = groundCheckEndpoint.position - transform.position;
        Physics2D.Raycast(transform.position, direction, new ContactFilter2D(), results, direction.magnitude);
        foreach (RaycastHit2D result in results)
        {
            if (result.collider && result.collider.gameObject != gameObject)
            {
                return result;
            }
        }
        
        return new RaycastHit2D();
    }
}
