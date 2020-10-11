using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravity : MonoBehaviour
{
    public void FlipGravityPlease()
    {
        Physics2D.gravity = -Physics2D.gravity;
    }
}
