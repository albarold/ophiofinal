using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNumber : MonoBehaviour
{
    public InventoryMenu CurrentRoom;
    public int Room_Number;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            CurrentRoom.InRoomNb = Room_Number;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
