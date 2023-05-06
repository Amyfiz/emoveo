using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventory;
    private bool inventoryOn;
    [SerializeField] private AudioSource inventorySound;

    private void Start()
    {
        inventoryOn = false;
        inventory.SetActive(false);
    }

    private void ShowInventory()
    {
        if (!inventoryOn)
        {
            inventory.SetActive(!inventory.activeSelf);
            inventorySound.Play();
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowInventory();
        }
    }
}
