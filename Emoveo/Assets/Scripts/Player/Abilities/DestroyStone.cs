using UnityEngine;

public class DestroyStone : MonoBehaviour
{
    private Player player;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && player.abilityToBreakWalls)
        {
            Destroy(gameObject);
            player.abilityToBreakWalls = false;
        }
    }
}
