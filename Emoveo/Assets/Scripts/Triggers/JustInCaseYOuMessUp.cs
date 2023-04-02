using UnityEngine;

public class JustInCaseYOuMessUp : MonoBehaviour
{
    private int enterCounter = 0;
    private Player player;
    public LeverState lever;
    public float x;
    public float y;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    
    public void OnTriggerStay2D(Collider2D other)
    {
        enterCounter++;

        if (enterCounter > 1 && !lever.activated && player.jumpForce == 16f)
        {
            player.transform.position = new Vector2(x, y);
        }
    }
}
