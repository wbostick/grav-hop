using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowardsGravity : MonoBehaviour
{
    void FixedUpdate()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (rigid)
        {
            rigid.SetRotation(Quaternion.LookRotation(Vector3.forward, -Physics2D.gravity.normalized));
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, -Physics2D.gravity.normalized);
        }
    }
}
