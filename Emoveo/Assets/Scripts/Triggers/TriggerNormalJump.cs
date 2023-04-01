using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNormalJump : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        player.jumpForce = 16f;
    }
}
