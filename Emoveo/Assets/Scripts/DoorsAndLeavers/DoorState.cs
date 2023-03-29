using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorState : MonoBehaviour
{
    public LeverState _leverState;

    public void Update()
    {
        if (_leverState.activated)
        {
            Destroy(gameObject);
        }
    }

}
