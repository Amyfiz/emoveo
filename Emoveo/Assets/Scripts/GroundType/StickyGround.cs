using UnityEngine;

public class StickyGround : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (player.isSticked)
        {
            player.isGrounded = true;
            player.GetComponent<Rigidbody2D>().gravityScale = player.stickyGravity;
            
        }
        else
        {
            player.GetComponent<Rigidbody2D>().gravityScale = player.normalGravity;
        }
    }
}
