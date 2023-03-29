using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverState : MonoBehaviour
{
    public GameObject lever;
    protected internal bool activated = false;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                activated = !activated;
            }

            if (lever.GetComponent<Collider2D>().isTrigger)
            {
                activated = !activated;
                Destroy(lever);
            }
        }
    }
}
