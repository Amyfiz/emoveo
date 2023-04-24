using System;
using UnityEngine;

public class LeverState : MonoBehaviour
{
    public GameObject lever;
    protected internal bool activated = false;
    public Collider2D collider;

    private void Awake()
    {
        collider = gameObject.GetComponent<Collider2D>();
    }

    public void Update()
    {
        if (collider.IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
        {
            Debug.Log("ЕСТЬ КОНТАКТ");
            if (Input.GetKeyDown(KeyCode.F))
            {
                activated = true;
            }
        }
    }
}
