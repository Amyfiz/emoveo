using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            audioSource.PlayOneShot();
    }
}
