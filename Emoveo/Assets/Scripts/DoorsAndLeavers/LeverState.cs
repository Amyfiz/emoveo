using UnityEngine;

public class LeverState : MonoBehaviour
{
    public GameObject lever;
    protected internal bool activated = false;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                activated = true;
            }
        }
    }
}
