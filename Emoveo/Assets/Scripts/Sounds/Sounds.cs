using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip runningSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            audioSource.PlayOneShot(runningSound);
    }
}
