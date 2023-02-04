using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventory;
    private bool inventoryOn;

    private void Start()
    {
        inventoryOn = false;
        inventory.SetActive(false);
    }

    public void ShowInventory()
    {
        if (inventoryOn == false)
        {
            inventory.SetActive(!inventory.activeSelf);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            ShowInventory();
        }
    }
}
