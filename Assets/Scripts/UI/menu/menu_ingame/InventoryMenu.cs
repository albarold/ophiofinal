using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public static bool InInventory = false;
    public GameObject InventoryMenuUI;
    public GameObject Map;


    public int InRoomNb;
    public Image[] Room_Highlight;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))//|| Input.GetButtonDown("Start")
        {
            if (InInventory)
            {
                Resume();
            }
            else
            {
                Inventory();
            }
        }

        for (int i = 0; i < Room_Highlight.Length; i++)
        {
            if (i == InRoomNb)
            {
                Room_Highlight[i].enabled = true;
            }
            else
            {
                Room_Highlight[i].enabled = false;
            }
        }
    }

    public void Resume()
    {
        InventoryMenuUI.SetActive(false);
        Time.timeScale = 1;
        InInventory = false;

    }
    public void Inventory()
    {
        InventoryMenuUI.SetActive(true);
        Time.timeScale = 0;
        InInventory = true;

    }

    public void Nextpage()
    {
        if (InInventory)
        {
            Debug.Log("next");
            Map.SetActive(true);
            InventoryMenuUI.SetActive(false);

            InInventory = false;

            LoadMap();
            
        }
        else
        {
            Debug.Log("next");
            Map.SetActive(false);
            InventoryMenuUI.SetActive(true);
            InInventory = true;

        }
        
    }

    public void LoadMap()
    {
        
       
    }

}
