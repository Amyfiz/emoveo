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
            player.position = new Vector3(player.position.x, player.position.y - player.localScale.y, player.position.z);
            player.localScale = new Vector3(player.localScale.x / 2f,player.localScale.y / 2f, player.localScale.z / 2f);
            //player.GetComponent<Player>().jumpForce = 4f;

        }

        if (item.name == "Confidence")
        {
            player.position = new Vector3(player.position.x, player.position.y + player.localScale.y, player.position.z);
            player.localScale = new Vector3(player.localScale.x * 2f,player.localScale.y * 2f, player.localScale.z * 2f);
        }

        if (item.name == "Impetuosity")
        {
            player.GetComponent<Player>().abilityToDash = true;
        }

        if (item.name == "Bravery")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -player.GetComponent<Rigidbody2D>().gravityScale;
            player.localScale = new Vector3(player.localScale.x, -player.localScale.y, player.localScale.z);
            player.GetComponent<Player>().jumpForce = -player.GetComponent<Player>().jumpForce;
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
}
