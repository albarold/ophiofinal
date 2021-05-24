using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class MainMenu : MonoBehaviour
{
    public GameObject Mainmenu;
    public GameObject OptionsMenu;
    public GameObject ControlsMap;
    public GameObject VolumeMenu;
    public bool IsActive;
     

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
    public void Options()
    {
        Debug.Log("ctrls");
        Mainmenu.SetActive(IsActive);
        IsActive = !IsActive;
        OptionsMenu.SetActive(IsActive);
        
    }
    public void Controls()
    {
        Debug.Log("ctrls");
        
        ControlsMap.SetActive(IsActive);
        IsActive= !IsActive;
    }

    public void Volumes()
    {
        Debug.Log("volume");
        VolumeMenu.SetActive(IsActive);
        IsActive = !IsActive;
        OptionsMenu.SetActive(IsActive);
    }

    public void Jouer()
    {
        SceneManager.LoadScene("BuildT 1");
    }
}
