using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool paused;
    public float sensitivity;

    public GameObject PauseMenu;

    void Start()
    {
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        paused = false;
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    public void Pause()
    {
        if (paused)
        {
            PauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            PauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

    }
    
    void UpdatePrefs()
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        PlayerPrefs.Save();
    }

}
