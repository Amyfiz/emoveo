using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool pauseMenuOn;
    public GameObject pauseMenu;
    public Player player;
    
    private void Start()
    {
        pauseMenuOn = false;
        pauseMenu.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPauseMenu();
        }
    }
    
    private void ShowPauseMenu()
    {
        if (!pauseMenuOn)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            /*
             player.abilityToDash = !player.abilityToDash;
            player.abilityToMove = !player.abilityToMove;
            player.abilityToSprint = !player.abilityToSprint;
            */
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("1_StartMenu");
    }
}
