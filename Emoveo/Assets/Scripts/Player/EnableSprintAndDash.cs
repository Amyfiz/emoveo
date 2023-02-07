using UnityEngine;

public class EnableSprintAndDash : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerController.GetComponent<Player>().abilityToDash = true;
        playerController.GetComponent<Player>().abilityToSprint = true;
    }
}