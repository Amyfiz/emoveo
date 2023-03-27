using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.Tilemaps;

public class StickyGround : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (player.isSticked)
        {
            player.isGrounded = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 50f;
            
        }
        else
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 3f;
        }
    }
}
