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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void CheckGravity()
    {
        if (player.GetComponent<Rigidbody2D>().gravityScale > 0f && player.GetComponent<Player>().jumpForce < 0f)
            player.GetComponent<Player>().jumpForce = -player.GetComponent<Player>().jumpForce;
        
        if (player.GetComponent<Rigidbody2D>().gravityScale < 0f && player.GetComponent<Player>().jumpForce > 0f)
            player.GetComponent<Player>().jumpForce = -player.GetComponent<Player>().jumpForce;
    }
    

    public void SpawnDroppedItem()
    {
        UseItem();
    }


    public void UseItem()
    {
        if (item.name == "Happiness")
        {
            player.GetComponent<Player>().jumpForce = 40f;
            CheckGravity();
            Jumped();
        }

        if (item.name == "Courage")
        {
            player.position = new Vector3(player.position.x, player.position.y - player.localScale.y, player.position.z);
            player.localScale = new Vector3(player.localScale.x / 2f,player.localScale.y / 2f, player.localScale.z / 2f);
            player.GetComponent<Player>().jumpForce = player.GetComponent<Player>().jumpForce / 2f;
        }

        if (item.name == "Confidence")
        {
            player.position = new Vector3(player.position.x, player.position.y + player.localScale.y, player.position.z);
            player.localScale = new Vector3(player.localScale.x * 2f,player.localScale.y * 2f, player.localScale.z * 2f);
            player.GetComponent<Player>().jumpForce = player.GetComponent<Player>().jumpForce * 2f;
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

        if (item.name == "Perseverance")
        {
            player.GetComponent<Player>().abilityToBreakWalls = true;
        }
    }

    private async Task Jumped()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<Player>().isGrounded)
            {
                player.GetComponent<Player>().jumpForce = 16f;
                CheckGravity();
                break;
            }
            await Task.Yield();
        }
    }
}
