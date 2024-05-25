using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonMenu : MonoBehaviour
    
   
{
    public AudioSource OnClickSound;
    // Start is called before the first frame update
    public void Start()
    {
        
    }
    public void Update()
    {
        
    }
    public void restart()
    {
        OnClickSound.Play();
        SceneManager.LoadScene(1);
        Debug.Log("chud");
    }
    public void menu()
    {
        OnClickSound.Play();
        SceneManager.LoadScene(0);
        Debug.Log("raha");
    }
    public void quit()

    {
        OnClickSound.Play();
        Application.Quit();
        Debug.Log("hai");
    }

}
