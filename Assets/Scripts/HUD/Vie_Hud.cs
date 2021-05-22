﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vie_Hud : MonoBehaviour
{
    public float TimerInvin;
    public int VieOphio;
    private GameObject Player;
    public int Life;
    public int NumOfHearts;
    public float InvincibiliteTps;
    private bool StartTimer;
    public int level;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    private void Start()
    {
        Player = this.gameObject;
        TimerInvin = InvincibiliteTps;
    }
    private void Update()
    {
        level = Parasitage.instance.Type;
        TimerInvin += Time.deltaTime;

        if(level == 0 && VieOphio >= Life)
        {            
            VieOphio = Life;
        }
        else if (level == 0 && VieOphio <= Life)
        {
            Life = VieOphio;
        }
        else if (level != 0)
        {
            Player.GetComponent<Parasitage>().Plife = Life;
        }

        Player.GetComponent<Parasitage>().Plife = Life;

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



        if (Life == 0)
        {

            Destroy(Player);
        }

    }


    public void TakeDamage(int degats)
    {
        if (Player.GetComponent<ChargeRework>().IsDashing == false)
        {


            if (InvincibiliteTps <= TimerInvin)
            {
                Life -= degats;
                TimerInvin = 0;
            }

        }
    }
}

