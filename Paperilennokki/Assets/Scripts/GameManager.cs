using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool paused;
    public float sensitivity;

    bool ended = false;

    public GameObject endObj;

    public float gameTime;

    public TextMeshProUGUI textjokutimer;
    public TextMeshProUGUI textjokutimer2;

    public float curTime;

    public GameObject PauseMenu;

    void Awake()
    {
        ended = false;

        curTime = gameTime;
        StartCoroutine(timerGame());

        paused = false;
        PauseMenu.SetActive(false);
        endObj.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if(curTime <= 0f)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            ended = true;
            endObj.SetActive(true);
        }
    }


    public void Pause()
    {
        if (paused && !ended)
        {
            PauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!paused && !ended)
        {
            PauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

    }
  
    public IEnumerator timerGame()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            curTime -= 1f;
            textjokutimer.text = "TIME: " + curTime.ToString();
            textjokutimer2.text = "TIME: " + curTime.ToString();
        }
    }


}
