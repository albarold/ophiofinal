using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Room : MonoBehaviour
{
    public GameObject[] GoToReset;
    private List<Vector2> V2ToReset = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GoToReset.Length; i++)
        {
            V2ToReset.Add(GoToReset[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            for (int i = 0; i < GoToReset.Length; i++)
            {
                GoToReset[i].transform.position = V2ToReset[i];
            }
        }
    }
}
