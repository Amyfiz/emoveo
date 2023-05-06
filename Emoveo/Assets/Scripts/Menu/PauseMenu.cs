using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pauseMenuOn;
    public GameObject pauseMenu;
    [SerializeField] private AudioSource menuButtonsSounds;

    private void Start()
    {
        pauseMenuOn = false;
        pauseMenu.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuButtonsSounds.Play();
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

    public void Continue()
    {
        ShowPauseMenu();
        menuButtonsSounds.Play();
    }

    public void QuitToMainMenu()
    { 
        Time.timeScale = 1;
        menuButtonsSounds.Play();
        SceneManager.LoadScene("1_StartMenu");
    }
}
