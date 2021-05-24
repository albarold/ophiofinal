using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vie_Hud : MonoBehaviour
{
    [HideInInspector]public int ReviveLife;
    [HideInInspector]public bool Revive =false;
    

    public float TimerInvin;
    private GameObject Player;
    public int Life;
    public int NumOfHearts;
    public float InvincibiliteTps;
    private bool StartTimer;
    public int level;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    public Image[] Hcorrupt;
    public Sprite Fullcorrupt;
    public Sprite Emptycorrupt;

    public int parasité;
    public int NumOfParasité;
    public GameObject Gameover;
    private void Start()
    {
        Player = this.gameObject;
        TimerInvin = InvincibiliteTps;
    }
    private void Update()
    {
        level = Parasitage.instance.Type;
        TimerInvin += Time.deltaTime;

        
        if (level == 0)
        {
            parasité = 0;
        }
        else if (level != 0)
        {
            Player.GetComponent<Parasitage>().Plife = parasité;
        }

        Player.GetComponent<Parasitage>().Plife = parasité;
        //vie Ophio
        if (Life > NumOfHearts)
        {
            Life = NumOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < Life)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < NumOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }

        //vie Parasité

        if (parasité > NumOfParasité)
        {
            parasité = NumOfParasité;
        }
        for (int i = 0; i < Hcorrupt.Length; i++)
        {

            if (i < parasité)
            {
                Hcorrupt[i].sprite = Fullcorrupt;
            }
            else
            {
                Hcorrupt[i].sprite = Emptycorrupt;
            }

            if (i < NumOfParasité)
            {
                Hcorrupt[i].enabled = true;
            }
            else
            {
                Hcorrupt[i].enabled = false;
            }

        }



        if (Life <= 0)
        {
            if (Revive)
            {
                TakeDamage(-ReviveLife);
                Revive = false;
                Debug.Log(Life);
            }
            else
            {
                Gameover.SetActive(true);

            }
            
        }

    }


    public void TakeDamage(int degats)
    {
        if (InvincibiliteTps <= TimerInvin)
        {
            if (Player.GetComponent<ChargeRework>().IsDashing == false)
            {

                if (parasité == 0)
                {
                    Life -= degats;
                }
                else if (parasité > 0)
                {
                    parasité -= degats;
                }
               

            }
            TimerInvin = 0;
        }
    }
}

