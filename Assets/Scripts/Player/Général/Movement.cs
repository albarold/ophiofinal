using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool Charge;
    public Vector2 change;
    private Rigidbody2D ORigidBody;

    public static Movement instance;
    private float timer;
    public float speed;
    public float SpeedOphio, SpeedReco, SpeedMineur,SpeedCata;


    private float KnockDur, KnockPower;
    private Transform Obj;
    // Start is called before the first frame update
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;

        instance = this;
    }
    void Start()
    {
        ORigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Obj != null)
        {
            Vector2 direction = (Obj.transform.position - this.transform.position).normalized;
            ORigidBody.velocity = -direction * KnockPower;

        }


        if (Charge)
        {
            
            timer += Time.deltaTime;
            

            if (timer>KnockDur)
            {
                timer = 0;
                Charge = false;
            }
        }
        if (!Charge)
        {
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            change = change.normalized;
            //ORigidBody.MovePosition(ORigidBody.position + change.normalized * speed * Time.fixedDeltaTime);
            ORigidBody.velocity = change * speed;
        }
        changeSpeed(this.GetComponent<Parasitage>().Type);
       
    }

    

    public IEnumerator KnockBack(float KnockDuration, float Knockpower, Transform obj)
    {
        ORigidBody.velocity = Vector3.zero;
        Charge = true;
        Obj = obj;
        KnockPower = Knockpower;
        KnockDur = KnockDuration;
        //Debug.Log("knockbacktime");
        yield return 0;
    }

    public void changeSpeed(int type)
    {

        switch (type)
        {
            case 0:
                speed = SpeedOphio;
                break;
            case 1:
                speed = SpeedReco;
                break;
            case 2:
                speed = SpeedMineur;
                break;
            case 3:
                speed = SpeedCata;
                break;
        }
    }

}
