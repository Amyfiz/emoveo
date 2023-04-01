using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private int scene;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
