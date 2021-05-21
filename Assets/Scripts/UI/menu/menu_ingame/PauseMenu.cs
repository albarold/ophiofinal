using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GamePaused = false;
    public GameObject PauseMenuUI;
    public GameObject ControlsMap;
    public GameObject Credits;
    public bool IsActive=true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//|| Input.GetButtonDown("Start")
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;

    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;

    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
    public void Credit()
    {
        Debug.Log("credits");
        ControlsMap.SetActive(IsActive);
        IsActive = !IsActive;
    }
    public void Controls()
    {
        Debug.Log("ctrls");
        ControlsMap.SetActive(IsActive);
        IsActive = !IsActive;
    }
}
