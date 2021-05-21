using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Dialogues : MonoBehaviour
{
    public GameObject[] Phrases;
    public float SkipCoolDown;

    private bool GamePaused; 
    private int PhraseIndex=0;
    private bool NotRead = true;



    private void Update()
    {
        if (Input.GetButtonDown("Sprint") && GamePaused)
        {
            Phrases[PhraseIndex].SetActive(false);
            PhraseIndex++;
            if (PhraseIndex == Phrases.Length)
            {
                Resume();
                PhraseIndex = 0;
            }
            else
            {
                Phrases[PhraseIndex].SetActive(true);
            }
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && NotRead)
        {
            Pause();
            Phrases[PhraseIndex].SetActive(true);
            NotRead = false;
        }
    }
    
    public void Resume()
    {
        GamePaused = false;
        Time.timeScale = 1;
    }
    void Pause()
    {
        GamePaused = true;
        Time.timeScale = 0;

    }

}
