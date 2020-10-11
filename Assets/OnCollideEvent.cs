using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollideEvent : MonoBehaviour
{
    public UnityEvent CollisionEnterEvent;

    private void OnCollisionEnter2D(Collision2D other)
    {
        CollisionEnterEvent.Invoke();
    }
}
