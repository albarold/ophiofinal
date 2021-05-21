using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Behavior : MonoBehaviour
{
    public GameObject PrefabMort;
    public GameObject Health_pos;
    public Vector3 Offset;
    

    public float Corrupt;
    public int E_Life;
    public int E_NumOfHearts;

    public Image[] E_hearts;
    public Sprite CorruptHeart;
    public Sprite E_FullHeart;
    public Sprite E_EmptyHeart;

    // Update is called once per frame
    void Update()
    {

        Health_pos.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);

        Life_Update();
    }

    void Life_Update()
    {
        if (E_Life > E_NumOfHearts)
        {
            E_Life = E_NumOfHearts;
        }

        for (int i = 0; i < E_hearts.Length; i++)
        {

            if (i < E_Life)
            {
                E_hearts[i].sprite = E_FullHeart;
            }
            else
            {
                E_hearts[i].sprite = E_EmptyHeart;
            }

            if (i < E_NumOfHearts)
            {
                E_hearts[i].enabled = true;
            }
            else
            {
                E_hearts[i].enabled = false;
            }
        }

        for (int i = E_Life; i > E_Life - Corrupt; i--)
        {
            E_hearts[E_Life - i].sprite = CorruptHeart;
        }

        if (Corrupt >= E_Life)
        {
            Corrupt = E_Life;
        }


        if (E_Life == 0)
        {
            transform.parent.gameObject.GetComponent<CreateDead>().Dead();
            Destroy(transform.parent.gameObject);
        }

    }
      
}

