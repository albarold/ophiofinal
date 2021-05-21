using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulteur_mech : MonoBehaviour
{
    public static InArea inArea_;
    public float timer;

    private Vector3 movement;
    private Vector2 Throw_Dir;

    public GameObject Throw_Collider;

    public GameObject Go_Cultivateur;
    public Rigidbody2D Rb_Cultivateur;
    private bool Used=false;
    private bool Used_Throw = false;

    public float Throw_Thrust;
    public float Knockback_Thrust;
    public float Push_Thrust;


    public bool Enemy_Area;
    public bool push_Area;
    private float dotproduct;

    private GameObject Go_Heavy_object;
    private Rigidbody2D Rb_Heavy_Object;

    // Start is called before the first frame update
    void Start()
    {
        inArea_ = InArea.instance;
        Throw_Dir = new Vector2(0f, -1f);
    }
    // Update is called once per frame
    void Update()
    {
        //Enemy_Area = inArea_.Enemy_inArea;
        //push_Area = inArea_.Push_Area;

        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        

        if (movement != Vector3.zero && Input.GetKey(KeyCode.E) == false)
            MoveCollider();
        
        
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }


        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Movement>().enabled = false;
            timer += Time.deltaTime;     
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (Enemy_Area && timer > 2)
            {
                Throwing();
            }

            GetComponent<Movement>().enabled = true;
            timer = 0;
        }
        
        if (push_Area && Input.GetKeyDown(KeyCode.E))
        {
            Push();
        }

        if (Used)
        {
            if (Rb_Heavy_Object.velocity.magnitude <= 0.5f)
            {
                Rb_Heavy_Object.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
        if (Used_Throw)
        {
            if(Rb_Cultivateur.velocity.magnitude < 0.5f)
            {
                //Go_Cultivateur.GetComponent<IA>().enabled = true; REMPLACER IA PAR L'IA DE L'ENEMY
            }
        }
    }


    public void MoveCollider()
    {

        if (movement.x > 0)
        {
            Throw_Dir = new Vector2(1f, 0f);
            Throw_Collider.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (movement.x < 0)
        {
            Throw_Dir = new Vector2(-1f, 0f);
            Throw_Collider.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (movement.y > 0)
        {
            Throw_Dir = new Vector2(0f, 1f);
            Throw_Collider.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (movement.y < 0)
        {
            Throw_Dir = new Vector2(0f, -1f);
            Throw_Collider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        

    }

    public void Throwing()
    {
        
        Debug.Log("yoooo");
        Go_Cultivateur = Throw_Collider.GetComponent<InArea>().Cultivateur; //recup go cultivateur qui entre dans zone
        Rb_Cultivateur = Go_Cultivateur.GetComponent<Rigidbody2D>();
        
        Rb_Cultivateur.AddForce(Throw_Dir * Throw_Thrust, ForceMode2D.Impulse);

        Used_Throw = false;

        //Go_Cultivateur.GetComponent<IA>().enabled = false; REMPLACER IA PAR L'IA DE L'ENEMY

    }

    public void Push()
    {
        Go_Heavy_object = inArea_.Heavy_ob; //recup Go heavy object qui entre dans zone
        Rb_Heavy_Object = Go_Heavy_object.GetComponent<Rigidbody2D>();
        Debug.Log("push");

        
        dotproduct = Vector2.Dot(DegreeToVector2(Throw_Collider.transform.eulerAngles.z), DegreeToVector2(Go_Heavy_object.transform.eulerAngles.z));
        
        
        if(dotproduct==1 || dotproduct==-1)
        {
            Rb_Heavy_Object.constraints = RigidbodyConstraints2D.None;
            Rb_Heavy_Object.constraints = RigidbodyConstraints2D.FreezeRotation;


            Rb_Heavy_Object.AddForce(Throw_Dir * Push_Thrust, ForceMode2D.Impulse);
            Debug.Log("addforce");
        }

        Used = true;

    }


    public void Attack()
    {
        Debug.Log("atk");
        Go_Cultivateur = Throw_Collider.GetComponent<InArea>().Cultivateur; //recup go cultivateur qui entre dans zone
        Rb_Cultivateur = Go_Cultivateur.GetComponent<Rigidbody2D>();

        //Go_Cutivateur.GetComponent<EVie>.degat()
        //remplacer degat par la fonction correspondante

        Rb_Cultivateur.AddForce(Throw_Dir * Knockback_Thrust, ForceMode2D.Impulse);

    }

    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
}
