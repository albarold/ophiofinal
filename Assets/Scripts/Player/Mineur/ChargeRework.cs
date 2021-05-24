using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeRework : MonoBehaviour
{
    public static Movement movement;
    [HideInInspector] public bool DuringChargement;
    public GameObject mineurMort;

    public float Speed1, Speed2, Speed3;
    public float  CoolDown2, CoolDown3;
    public float ChargementCharge;

    private float timeStop;
    private GameObject Player;
    private Rigidbody2D RbPlayer;
    private Vector2 Direction;
    private float Speed;
    [HideInInspector] public float DuringDash;
    private float DashTimer;

    private float timer;
    public bool IsDashing = false;
    public float DashTimerStart;
    private Vector2 Dir;

    public float DashForce;
    public float DashCooldown;
    private float TimeDash;
    public int DegatDash;

    public GameObject FxChargeC1, FxChargeC2, FxChargeC3;
    public bool charge;
    void Start()
    {
        movement = Movement.instance;
        Player = this.gameObject;
        RbPlayer = Player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayFX();
        if (Input.GetButton("Depara"))
        {
            Debug.Log("Depara");
            Parasitage.instance.Type = 0;
            Instantiate(mineurMort, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        if (RbPlayer.velocity==Vector2.zero)
        {
            timeStop += Time.deltaTime;
            if (timeStop>0.5)
            {
                charge = false;
            }
        }
        else
        {
            timeStop = 0;
        }
        if (charge==false)
        {
            Player.GetComponent<Movement>().enabled = true;
            FxChargeC1.transform.rotation = Quaternion.Euler(0, 0, 0);
            FxChargeC2.transform.rotation = Quaternion.Euler(0, 0, 0);
            FxChargeC3.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        TimeDash += Time.deltaTime;

        Direction=movement.change;
        if (DashTimer>0)
        {
            Debug.Log("Dash");
            RbPlayer.velocity=Direction * DashForce;
        }
        else
        {
            IsDashing = false;
        }

        if (!IsDashing )
        {
            Player.GetComponent<Movement>().enabled = true;
            if (Input.GetButtonDown("Dash") && TimeDash>DashCooldown && !charge)
            {
                
                DashTimer = DashTimerStart;
                IsDashing = true;
                TimeDash = 0;
            }
        }
        else
        {
            DashTimer -= Time.deltaTime;
            Player.GetComponent<Movement>().enabled = false;
            
        }
        //************************************************
        if (Input.GetButton("Sprint"))
        {
            DuringChargement = true;
            RbPlayer.velocity = Vector2.zero;
            Dir = Direction;
            Player.GetComponent<Movement>().enabled = false;
            timer += Time.deltaTime;
        }

        if (Input.GetButtonUp("Sprint"))
        {
            DuringChargement = false;
            if (timer >= ChargementCharge)
            {

                charge = true;
                Speed = Speed1;
                Charge();
                timer = 0;
            }
            else
            {
                Player.GetComponent<Movement>().enabled = true;
                timer = 0;
            }
        }



        if (charge)
        {
            DuringDash += Time.deltaTime;
            Player.GetComponent<Movement>().enabled = false;

            if (DuringDash >= CoolDown3)
            {
                Speed = Speed3;
                Charge();
            }
            else if (DuringDash >= CoolDown2)
            {
                Speed = Speed2;
                Charge();
            }
            else
            {
                Charge();
            }
            
        }

        


    }
    
    public void Charge()
    {
        if (Mathf.Abs(Dir.x)>=Mathf.Abs(Dir.y))
        {
            if (Dir.x >= 0)
            {
                RbPlayer.velocity = Vector2.right * Speed;
            }
            else
            {
                RbPlayer.velocity = Vector2.left * Speed;

            }
        }
        else
        {
            if (Dir.y >= 0)
            {
                RbPlayer.velocity = Vector2.up * Speed;
                

            }
            else
            {
                RbPlayer.velocity = Vector2.down * Speed;
              
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (IsDashing)
        {
            if (collision.gameObject.CompareTag("Insecte1") || collision.gameObject.CompareTag("Insecte2") || collision.gameObject.CompareTag("Insecte3"))
            {
                collision.gameObject.GetComponentInChildren<HealthBar_Behavior>().E_Life -= DegatDash;
            }
        }


        if (charge)
        {
            if (collision.gameObject.CompareTag("BoxLv1"))
            {
                if (Speed>=Speed1)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    Debug.Log("stop1");
                    Player.GetComponent<Movement>().enabled = true;
                    charge = false;
                    DuringDash = 0;
                }
            }
            else if (collision.gameObject.CompareTag("BoxLv2"))
            {
                if (Speed>=Speed2)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    Debug.Log("stop2");
                    Player.GetComponent<Movement>().enabled = true;
                    charge = false;
                    DuringDash = 0;
                }
            }
            else if (collision.gameObject.CompareTag("BoxLv3"))
            {
                if (Speed >= Speed3)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    Debug.Log("stop3");
                    Player.GetComponent<Movement>().enabled = true;
                    charge = false;
                    DuringDash = 0;
                }
            }
            else if ( !collision.gameObject.CompareTag("BoxLv1") || !collision.gameObject.CompareTag("BoxLv2") || !collision.gameObject.CompareTag("BoxLv3"))
            {
                Player.GetComponent<Movement>().enabled = true;
                Debug.Log("test");
                charge = false;
                DuringDash = 0;
            }
        }
    }

    public void PlayFX()
    {
       
        if (charge)
        {
            if (Speed == Speed1)
            {
                FxChargeC1.SetActive(true);
                FxChargeC2.SetActive(false);
                FxChargeC3.SetActive(false);
            }


            if (Speed == Speed2)
            {
                FxChargeC1.SetActive(false);
                FxChargeC2.SetActive(true);
                FxChargeC3.SetActive(false);

            }
            if (Speed == Speed3)
            {
                FxChargeC1.SetActive(false);
                FxChargeC2.SetActive(false);
                FxChargeC3.SetActive(true);
            } 
        }
        else
        {
            FxChargeC1.SetActive(false);
            FxChargeC2.SetActive(false);
            FxChargeC3.SetActive(false);

        }

        if (Mathf.Abs(Dir.x) >= Mathf.Abs(Dir.y))
        {
            if (Dir.x >= 0)
            {
                
                FxChargeC1.transform.rotation = Quaternion.Euler(0, 0, 180);
                FxChargeC2.transform.rotation = Quaternion.Euler(0, 0, 180);
                FxChargeC3.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if(Dir.x <= 0)
            {
               
                FxChargeC1.transform.rotation = Quaternion.Euler(0, 0, 180);
                FxChargeC2.transform.rotation = Quaternion.Euler(0, 0, 180);
                FxChargeC3.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        else
        {
            if (Dir.y >= 0)
            {
                
                FxChargeC1.transform.rotation = Quaternion.Euler(0, 0, 90);
                FxChargeC2.transform.rotation = Quaternion.Euler(0, 0, 90);
                FxChargeC3.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Dir.y <= 0)
            {
               
                FxChargeC1.transform.rotation = Quaternion.Euler(0, 0, -90);
                FxChargeC2.transform.rotation = Quaternion.Euler(0, 0, -90);
                FxChargeC3.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        }
    }
}