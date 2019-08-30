using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PausePrefab;
    [SerializeField] GameObject DeathPanel;

    GameObject canvas;
    GameObject pauseMenu;

    //private void Awake()
    //{
    //    if(SceneManager.GetActiveScene().buildIndex==1)
    //    canvas = GameObject.Find("Canvas");
    //}

    //private void Update()
    //{
    //    Debug.Log(canvas);
    //}

    public void Pause()
    {
        //show window
        //if (SceneManager.GetActiveScene().buildIndex == 1)
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
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void PlayerDeath()
    {
        canvas = GameObject.Find("Canvas");
        Instantiate(DeathPanel, canvas.transform);
    }
}
