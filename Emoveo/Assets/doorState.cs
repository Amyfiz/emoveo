using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorState : MonoBehaviour
{
    public leverState _leverState;

    public void Update()
    {
        this.GetComponent<Collider2D>().isTrigger = _leverState.activated;
    }

}
