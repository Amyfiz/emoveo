using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
