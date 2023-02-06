using UnityEngine;

public class InventoryCell : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public KeyCode keyCode;

    public void Use()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        //Проверка пустоты ячейки
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
        else
        {
            inventory.isFull[i] = true;
        }

        if ((Input.GetKeyDown(keyCode) && (inventory.isFull[i])))
        {
            Use();
        }
    }
}

