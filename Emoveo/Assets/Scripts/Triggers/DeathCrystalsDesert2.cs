using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCrystalsDesert2 : MonoBehaviour
{
    private Player player;
    private Inventory inventory;
    public float x1;
    public float y1;
    public float x2;
    public float y2;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (player.GetComponent<Rigidbody2D>().gravityScale > 0 && !inventory.isFull[0])
        {
            player.transform.position = new Vector2(x1, y1);
        }
        else
        {
            player.transform.position = new Vector2(x2, y2);
        }
    }
}