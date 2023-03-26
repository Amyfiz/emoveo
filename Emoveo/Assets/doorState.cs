using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorState : MonoBehaviour
{
    public leverState _leverState;
    private bool isOpened;

    public void Update()
    {
        isOpened = _leverState.activated;

    }

}
