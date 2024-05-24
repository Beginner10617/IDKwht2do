using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostMenu : MonoBehaviour
{
    public AudioSource OnClickSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart()
    {
        OnClickSound.Play();
        SceneManager.LoadScene(1);
    }
    public void menu()
    {
        OnClickSound.Play();
        SceneManager.LoadScene(0);
    }
    public void quit()

    {
        OnClickSound.Play();
        Application.Quit();
    }

}
