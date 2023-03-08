using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
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
        if (item.name == "Happiness")
        {
            player.GetComponent<Player>().jumpForce = 30f;
            Jumped();
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
                Vector2 playerPos = new Vector2((player.position.x + 5f * faceDirection), player.position.y);
                Instantiate(item, playerPos, Quaternion.identity);
            }
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
                Vector2 playerPos = new Vector2((player.position.x + 5f * faceDirection), player.position.y);
                Instantiate(item, playerPos, Quaternion.identity);
            }
        }

        if (item.name == "Impetuosity")
        {
            player.GetComponent<Player>().abilityToDash = true;
            /*Dashed();*/
        }
    }

    private async Task Jumped()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                break;
            }
            await Task.Yield();
        }
        player.GetComponent<Player>().jumpForce = 6f;
    }

    /*private async Task Dashed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !player.GetComponent<Player>().isGrounded)
            await Task.Yield();
        player.GetComponent<PlayerController>().Dash();
        player.GetComponent<Player>().abilityToDash = false;
    }*/
}
