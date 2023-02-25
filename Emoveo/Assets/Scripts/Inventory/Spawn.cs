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
        if (player.GetComponent<Player>().facingRight)
            direction = 1f;
        else
            direction = -1f;
    }

    public void SpawnDroppedItem()
    {
        UseItem();
    }

    public void UseItem()
    {
        if (item.name == "Happiness")
        {
            Vector2 playerPos = new Vector2((player.position.x + 5f * direction), player.position.y - 2);
            Instantiate(item, playerPos, Quaternion.identity);
        }

        if (item.name == "Courage")
        {
            if (player.localScale == new Vector3(1f * direction, 1f, 1f))
                player.localScale = new Vector3(0.2f * direction, 0.2f, 0.2f);
            
            else
            {
                player.position = new Vector3(player.position.x, player.position.y + 1.2f, player.position.z); 
                player.localScale = new Vector3(1f * direction, 1f, 1f);
            }


            /*if (player.GetComponent<Player>().facingRight)
                player.position = new Vector3(player.position.x + 5f, player.position.y, player.position.z);
            else
                player.position = new Vector3(player.position.x - 5f, player.position.y, player.position.z);*/
        }
    }
}
