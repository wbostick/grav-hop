using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public void ResetScenePlease(float timeUntilReset)
    {
        StartCoroutine(ResetCo(timeUntilReset));
    }

    IEnumerator ResetCo(float timeUntilReset)
    {
        yield return new WaitForSecondsRealtime(timeUntilReset);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
