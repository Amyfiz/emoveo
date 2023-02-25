using System;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private float direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        
    }

    public void SpawnDroppedItem()
    {
        UseItem();
    }

    public void UseItem()
    {
        if (item.name == "Happiness")
        {
            Vector2 playerPos = new Vector2();
            if (player.GetComponent<Player>().facingRight)
                playerPos = new Vector2((player.position.x + 5f), player.position.y - 2);
            else
                playerPos = new Vector2((player.position.x - 5f), player.position.y - 2);
                Instantiate(item, playerPos, Quaternion.identity);
        }

        if (item.name == "Courage")
        {
            if (player.GetComponent<Player>().facingRight)
                player.position = new Vector3(player.position.x + 5f, player.position.y, player.position.z);
            else
                player.position = new Vector3(player.position.x - 5f, player.position.y, player.position.z);
        }
    }
}
