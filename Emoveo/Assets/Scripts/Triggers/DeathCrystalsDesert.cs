using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCrystalsDesert : MonoBehaviour
{
    private Player player;
    public float x1;
    public float y1;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        player.transform.position = new Vector2(x1, y1);
    }
}