using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool pauseMenuOn;
    public GameObject pauseMenu;
    private Player player;
    
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
            player.abilityToDash = false;
            player.abilityToMove = false;
            player.abilityToSprint = false;
        }
    }
    
    private void ShowPauseMenu()
    {
        if (!pauseMenuOn)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("1_StartMenu");
    }
}
