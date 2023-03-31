using UnityEngine;
using UnityEngine.SceneManagement;

public class GodModeMenu : MonoBehaviour
{
    public bool godModeOn;
    public GameObject godModeMenu;
    public Player player;
    public GameObject dialogueTriggers;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    private void Start()
    {
        dialogueTriggers = GameObject.FindGameObjectWithTag("DialogueTriggers");
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
        player.GetComponent<Player>().playerSpeed = 20f;
        player.GetComponent<Player>().abilityToDash = true;
        player.GetComponent<Player>().abilityToSprint = true;
        //player.GetComponent<Player>().jumpForce = 6f;
        player.GetComponent<Player>().whatIsGrounded = LayerMask.NameToLayer("UI");
    }
    
    public void Decrease()
    {
        player.GetComponent<Player>().playerSpeed = 5f;
        //player.GetComponent<Player>().jumpForce = 4f;
        player.GetComponent<Player>().whatIsGrounded = LayerMask.GetMask("Ground");
    }

    public void RemoveDialogues()
    {
        Destroy(dialogueTriggers);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}