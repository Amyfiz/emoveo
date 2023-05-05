using UnityEngine;

public class DeathCrystals : MonoBehaviour
{
    private Player player;
    public LeverState lever;
    public float x1;
    public float y1;
    public float x2;
    public float y2;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    
    public void OnTriggerStay2D(Collider2D other)
    {
        if (!lever.activated)
        {
            player.transform.position = new Vector2(x1, y1);
        }
        else
        {
            player.transform.position = new Vector2(x2, y2);
        }
    }
}
