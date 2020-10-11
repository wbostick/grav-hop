using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public Vector2 gravityDirection;
    float gravityStrength;
    Rigidbody2D rigid;
    public Transform gravityCheckEndpoint;
    public Transform jumpCheckEndpoint;

    private void Awake()
    {
        gravityDirection = -transform.up;
        gravityStrength = Physics2D.gravity.magnitude;

        Physics2D.gravity = gravityDirection * gravityStrength;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collsiion)
    {
        Vector2 newestNormal = collsiion.GetContact(collsiion.contactCount - 1).normal.normalized;
        Physics2D.gravity = -newestNormal * gravityStrength;
        rigid.SetRotation(Quaternion.LookRotation(Vector3.forward, newestNormal));
    }

    public RaycastHit2D GetGround(Transform endpoint)
    {
        RaycastHit2D[] results = new RaycastHit2D[2];
        Vector2 direction = endpoint.position - transform.position;
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

    public bool IsGronudedForJump()
    {
        return GetGround(jumpCheckEndpoint).collider != null;
    }
}
