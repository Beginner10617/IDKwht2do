using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject InstructionPanel;
    public GameObject Main;
    public AudioSource OnClickSound;
    // Start is called before the first frame update
    void Start()
    {
        
        InstructionPanel.SetActive(false);
        Main.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void Play()
    {
        OnClickSound.Play();
        SceneManager.LoadScene(1);
    }
    public void OnApplicationQuit()
    {
        OnClickSound.Play();
        Application.Quit();
        Debug.Log("fuckYou");
    }
    public void showInstructionPanel()
    {
        OnClickSound.Play();
        InstructionPanel.SetActive(true);
        Main.SetActive(false);
    }
    public void back()
    {
        OnClickSound.Play();
        InstructionPanel.SetActive(false);
        Main.SetActive(true);
    }

}
