using System;
using UnityEngine;

public class LeverState : MonoBehaviour
{
    public GameObject lever;
    protected internal bool activated = false;
    private Collider2D collider;

    private void Awake()
    {
        collider = gameObject.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (collider.IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                activated = true;
            }
        }
    }
}
