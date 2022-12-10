using UnityEngine;

public class EnableSprintAndDash : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerController.abilityToDash = true;
        playerController.abilityToSprint = true;
    }
}