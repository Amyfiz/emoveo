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

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("1_StartMenu");
    }
}