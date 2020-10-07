using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToNext : MonoBehaviour
{
    //public float pullStrength = 50f;
    public float spinSpeed = 5000f;
    bool spinning = false;
    public float pullDuration = 1f;

    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(IntoThePortal());
        }
    }

    IEnumerator IntoThePortal()
    {
        player.GetComponent<Rigidbody2D>().angularVelocity = spinSpeed;

        Vector2 initialPosition = player.transform.position;
        float startTime = Time.time;

        float timer = 0;
        do
        {
            player.transform.position = Vector2.Lerp(initialPosition, transform.position, timer/pullDuration);
            yield return null;
            timer = Time.time - startTime;
        } while (timer < pullDuration);

        int nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextScene);
    }
}
