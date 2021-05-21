using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public float speed;
    public float DashSpeed;
    private float DashTime;
    public float startDashTime;
    public int direction;
    public Rigidbody2D CRigidBody;
    private Vector3 Cchange;
    public float wait;
    public bool charge;
    public int Nivcharge;
    public int Charge1;
    public int Charge2;
    public int Charge3;
    public float timeStop;
    public int levelC;

    public int attaque;
    void Start()
    {
        CRigidBody = GetComponent<Rigidbody2D>();
        DashTime = startDashTime;
        Charge1 = 1;
        Charge2 = 2;
        Charge3 = 3;
    }

    // Update is called once per frame
    void Update()
    {
        levelC = Parasitage.instance.Type;
        if (charge = true && CRigidBody.velocity.magnitude < 0.1f)
        {
            charge = false;
        }

        timeStop += Time.deltaTime;
        if (timeStop > 0.5)
        {
            timeStop = 0;
            direction = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            charge = true;
        }

        if (charge)
        {
            wait += Time.deltaTime;
        }

        MCharge();


        if (charge)
        {
            if (wait < Charge1 && wait > 0)
            {
                Nivcharge = 1;
                Debug.Log("Charge 1");

            }
            if (wait < Charge2 && wait > Charge1)
            {
                Nivcharge = 2;
                DashSpeed = 30;
                Debug.Log("Charge 2");

            }
            if (wait < Charge3 && wait > Charge2)
            {

                Nivcharge = 3;
                DashSpeed = 40;
                Debug.Log("Charge 3");
            }



        }




        if (direction == 0)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {

                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {

                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {

                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                direction = 4;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            levelC = 0;
        }

    }

    public void MCharge()
    {

        if (Input.GetMouseButton(0))
        {
            charge = true;
            if (Nivcharge == 1)
            {
                if (direction == 1)
                {
                    CRigidBody.velocity = Vector2.left * DashSpeed;

                }
                else if (direction == 2)
                {
                    CRigidBody.velocity = Vector2.right * DashSpeed;

                }
                else if (direction == 3)
                {
                    CRigidBody.velocity = Vector2.up * DashSpeed;

                }
                else if (direction == 4)
                {
                    CRigidBody.velocity = Vector2.down * DashSpeed;

                }
            }


            if (Nivcharge == 2)
            {

                if (direction == 1)
                {
                    CRigidBody.velocity = Vector2.left * DashSpeed;

                }
                else if (direction == 2)
                {
                    CRigidBody.velocity = Vector2.right * DashSpeed;

                }
                else if (direction == 3)
                {
                    CRigidBody.velocity = Vector2.up * DashSpeed;

                }
                else if (direction == 4)
                {
                    CRigidBody.velocity = Vector2.down * DashSpeed;

                }
            }

            if (Nivcharge == 3)
            {

                if (direction == 1)
                {
                    CRigidBody.velocity = Vector2.left * DashSpeed;

                }
                else if (direction == 2)
                {
                    CRigidBody.velocity = Vector2.right * DashSpeed;

                }
                else if (direction == 3)
                {
                    CRigidBody.velocity = Vector2.up * DashSpeed;

                }
                else if (direction == 4)
                {
                    CRigidBody.velocity = Vector2.down * DashSpeed;

                }
            }
        }


    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxLv1"))
        {
            if (Nivcharge == 1)
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("BoxLv2"))
        {
            if (Nivcharge == 2)
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("BoxLv3"))
        {
            if (Nivcharge == 3)
            {
                Destroy(collision.gameObject);
            }
        }

    }
    */


}
