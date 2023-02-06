using System;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        UseItem();
    }

    public void UseItem()
    {
        if (item.name == "Happiness")
        {
            Vector2 playerPos = new Vector2(player.position.x + 5, player.position.y - 2);
            Instantiate(item, playerPos, Quaternion.identity);
        }

        if (item.name == "Courage")
        {
            player.position = new Vector3(player.position.x + 5, player.position.y, player.position.z);
        }
    }
}
