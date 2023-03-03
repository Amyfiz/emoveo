using System;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private float faceDirection;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player.GetComponent<Player>().facingRight)
            faceDirection = 1f;
        else
            faceDirection = -1f;
    }
    public void SpawnDroppedItem()
    {
        UseItem();
    }
    

    public void UseItem()
    {
        bool jumped = false;
        if (item.name == "Happiness")
        {
            if(!player.GetComponent<Player>().isJumping)
            {
                player.GetComponent<Player>().jumpForce = 30f;
            }
        }

        if (item.name == "Courage")
        {
            if (player.localScale == new Vector3(0.45f * faceDirection, 0.45f, 0.45f))
            {
                player.localScale = new Vector3(0.2f * faceDirection, 0.2f, 0.2f);
                player.GetComponent<Player>().jumpForce = 4f;
            }
            else
            {
                Vector2 playerPos = new Vector2((player.position.x + 5f * faceDirection), player.position.y - 2);
                Instantiate(item, playerPos, Quaternion.identity);
            }

            /*if (player.GetComponent<Player>().facingRight)
                player.position = new Vector3(player.position.x + 5f, player.position.y, player.position.z);
            else
                player.position = new Vector3(player.position.x - 5f, player.position.y, player.position.z);*/
        }

        if (item.name == "Confidence")
        {
            if (player.localScale == new Vector3(0.2f * faceDirection, 0.2f, 0.2f))
            {
                player.position = new Vector3(player.position.x, player.position.y + 0.7f, player.position.z);
                player.localScale = new Vector3(0.5f * faceDirection, 0.5f, 0.5f);
                player.GetComponent<Player>().jumpForce = 6f;
            }
            else
            {
                Vector2 playerPos = new Vector2((player.position.x + 5f * faceDirection), player.position.y - 2);
                Instantiate(item, playerPos, Quaternion.identity);
            }

        }

    }
}
