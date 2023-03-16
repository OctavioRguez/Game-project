using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;

    [SerializeField]private GameObject PauseMenuUI, SettingsMenu, QuitMenu, DiedMenu, QuitDiedMenu;
    [SerializeField]private Slider volume;
    public bool Die = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Die == false)
        {
            if (GamePause == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else if (Die == true)
        {
            DiedMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
        AudioListener.volume = volume.value;
    }

    public void Resume()
    {
        if (Die == true)
        {
            DiedMenu.SetActive(false);
            Time.timeScale = 1f;
            Die = false;
        }
        else
        {
            PauseMenuUI.SetActive(false);
            QuitMenu.SetActive(false);
            SettingsMenu.SetActive(false);
            Time.timeScale = 1f;
            GamePause = false;
        }
    }

    public void Retry()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GamePause = true;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void BackMenu()
    {
        Die = false;
        DiedMenu.SetActive(false);
        QuitDiedMenu.SetActive(true);
    }
}
