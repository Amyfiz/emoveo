using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

public class leverState : MonoBehaviour
{
    public GameObject lever;
    protected internal bool activated = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activated = !activated;
            Destroy(lever); 
        }
    }
    
}
