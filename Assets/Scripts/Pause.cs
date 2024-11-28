using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] List<GameObject> toClose;
    void Start()
    {
        isPaused = false;        
    }
    void Update()
    {
        pauseMenu.SetActive(isPaused);
        pauseButton.SetActive(!isPaused);
        foreach(GameObject obj in toClose)
        {
            obj.SetActive(!isPaused);
        }
        if(isPaused) Time.timeScale=0;
        else Time.timeScale=1;
    }
    public void pause()
    {
        isPaused = true;
    }
    public void resume()
    {
        isPaused = false;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
}
