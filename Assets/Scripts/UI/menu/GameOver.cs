using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void Update()
    {
        Time.timeScale = 0;
        if (Input.GetButton("Attaque"))
        {
            SceneManager.LoadScene("Menu_Jeu");
        }
    }
        
}
