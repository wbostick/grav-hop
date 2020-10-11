using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollideEvent : MonoBehaviour
{
    public UnityEvent CollisionEnterEvent;
    public UnityEvent TriggerEnterEvent;
    private void OnCollisionEnter2D(Collision2D other)
    {
        CollisionEnterEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TriggerEnterEvent.Invoke();
    }
}
