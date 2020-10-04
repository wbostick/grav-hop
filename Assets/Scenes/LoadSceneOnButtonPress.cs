using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadSceneOnButtonPress : MonoBehaviour
{
    public string sceneToLoad = "Menu";
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {SceneManager.LoadScene(sceneToLoad);});
    }
}
