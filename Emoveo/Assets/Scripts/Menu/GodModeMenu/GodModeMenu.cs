using UnityEngine;
using UnityEngine.SceneManagement;

public class GodModeMenu : MonoBehaviour
{
    public bool godModeOn;
    public GameObject godModeMenu;
    
    public Player player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    private void Start()
    {
        godModeOn = false;
        godModeMenu.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowGodModeMenu();
        }
    }

    public void ShowGodModeMenu()
    {
        if (!godModeOn)
        {
            godModeMenu.SetActive(!godModeMenu.activeSelf);
            
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }
    }
    
    public void Continue()
    {
        ShowGodModeMenu();
    }
    
    public void Increase()
    {
        player.GetComponent<Player>().playerSpeed += 5f;
    }
}