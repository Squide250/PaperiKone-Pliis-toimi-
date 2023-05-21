using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class maninmenu : MonoBehaviour
{
    void Start()
    {
        
    }


    public void Play()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        print("qit");
        Application.Quit();
    }
}
