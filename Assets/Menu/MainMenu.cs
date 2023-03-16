using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Slider volume;
    public GameObject Page1, Page2;
    private int page = 1;

    void Update()
    {
        AudioListener.volume = volume.value;
    }

    public void ContinueGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Pages()
    {
        if (page == 1)
        {
            Page1.SetActive(false);
            Page2.SetActive(true);
            page = 2;
        }
        else if (page == 2)
        {
            Page1.SetActive(true);
            Page2.SetActive(false);
            page = 1;
        }
    }
}
