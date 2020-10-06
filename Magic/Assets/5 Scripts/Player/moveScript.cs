using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moveScript : MonoBehaviour
{
    public float maxSpeed = 10f; //Максимальная скорость передвижения
    public float jumpForce = 800f; //Сила прыжка
    Rigidbody2D Rigidbody;
    //Animator Hero;
    Animator Hero;
    Collider2D Col;
    SpriteRenderer Sprite;
    public GameObject Colba;
    public float moveX;
    public float moveY;
    public static float LastmoveX;
    public static float LastmoveY;
    public bool stop = false;
    GameObject LoadManager;
    public FixedJoystick JStick;// Джойстик

    public GameObject AimObj;
    bool IsAim = false;

    void Start()
    {
        Hero = GetComponent<Animator>();
        Col = GetComponent<Collider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        //Hero = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        try{JStick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>(); } catch{ } ;
        LoadManager = GameObject.Find("LevelMananger");
        AimObj.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stop) return;
         
        if(Statistic.Joyst == 1)
        {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        }
        else
        {
        moveX = JStick.Horizontal;
        moveY = JStick.Vertical;
        }

        try{
        AimObj.transform.rotation = Quaternion.Euler(0, 0, Degree.GetDegree(moveX, moveY));
        }
        catch{}

        if ((Input.GetKeyDown("return") || Input.GetKeyDown("enter") || Input.GetAxis("Fire1") > 0) && Statistic.Joyst == 1)
        {
            if (!Character.IsAttackSpell)
            {
                IsAim = true;
                return;
            }
            Aim();
        }

        if ((Input.GetKeyUp("return") || Input.GetKeyUp("enter") || Input.GetAxis("Fire1") == 0) && IsAim && Statistic.Joyst == 1)// button 0
        {
            Throw();
        }

        if ((Input.GetAxis("Fire2") > 0) && Statistic.Joyst == 1)// button 1
        {
            LoadManager.GetComponent<LoadLevel>().LoadFromMenu(1);
        }

        if ((Input.GetAxis("Fire3") > 0) && Statistic.Joyst == 1)// button 2
        {
            LoadManager.GetComponent<LoadLevel>().Load();
        }

        if ((Input.GetAxis("Fire4") > 0) && Statistic.Joyst == 1)// button 3
        {
            GameObject.Find("Canvasv2").GetComponent<IngameInterface>().ChangePointer();
        }

        if (Input.GetKeyDown(KeyCode.Space))
         {
            Throw();
         }
        if (!Hero.GetBool("Attack"))
        {

            if (!IsAim)
            {
                Rigidbody.velocity = new Vector2(moveX, moveY).normalized * maxSpeed;
            }
            else
            {
                Rigidbody.velocity = Vector2.zero;
            }

            if (moveX == 0 && moveY == 0)
            {
                Hero.SetInteger("Vector", Hero.GetInteger("Vector"));
                Hero.speed = 0;
                return;
            }

            if (moveX > 0 &&  Mathf.Abs(moveX)  > Mathf.Abs(moveY))
            {
                Hero.SetInteger("Vector", 3);
                Hero.speed = 1;
            }

            if (moveX < 0 && Mathf.Abs(moveX) > Mathf.Abs(moveY))
            {
                Hero.SetInteger("Vector", 1);
                Hero.speed = 1;
            }

            if (moveY > 0 && Mathf.Abs(moveX) < Mathf.Abs(moveY))
            {
                Hero.SetInteger("Vector", 2);
                Hero.speed = 1;
            }

            if (moveY < 0 && Mathf.Abs(moveX) < Mathf.Abs(moveY))
            {
                Hero.SetInteger("Vector", 4);
                Hero.speed = 1;
            }
        }
        else
        {
            Rigidbody.velocity = Vector2.zero;
        }


    }
     
    public void Throw()
    {
        AimObj.GetComponent<SpriteRenderer>().enabled = false;
        IsAim = false;
        if (Character.combination[Character.pointer] != 0)
        {
            gameObject.GetComponent<SpawnSpell>().Spawn(gameObject);
            Hero.SetBool("Attack", true);
            StartCoroutine(waitAttack());

        }
    }

    public void Aim()
    {
        if (!Character.IsAttackSpell)
        {
            IsAim = true;
            return;
        }

        AimObj.GetComponent<SpriteRenderer>().enabled = true;
        IsAim = true;
    }

    IEnumerator waitAttack()
    {
        yield return new WaitForSeconds(0.5f);
        Hero.SetBool("Attack", false);
        GameObject.Find("Canvasv2").GetComponent<IngameInterface>().ChangePointer();
    }

    public void punch(Vector2 vec)
    {
        Vector2 vel = Rigidbody.velocity;
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.AddForce(-vel * 2 , ForceMode2D.Impulse);
        if(vec != null)
        {
            Rigidbody.velocity = Vector2.zero;
            Rigidbody.AddForce(-vec * 2, ForceMode2D.Impulse);
        }
    }
}
