using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PausePrefab=null;
    [SerializeField] GameObject DeathPanel=null;

    GameObject pauseMenu;
    GameObject canvas;

    public void Pause()
    {
        canvas = GameObject.Find("Canvas");
        pauseMenu =Instantiate(PausePrefab, canvas.transform);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        //close window
        Destroy(pauseMenu);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }

    public void PlayerDeath()
    {
        canvas = GameObject.Find("Canvas");
        Instantiate(DeathPanel, canvas.transform);
    }
}
