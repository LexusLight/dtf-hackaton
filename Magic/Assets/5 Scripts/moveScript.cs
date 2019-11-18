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

    // Use this for initialization
    void Start()
    {
        Hero = GetComponent<Animator>();
        Col = GetComponent<Collider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        //Hero = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        

         if (Input.GetKeyDown(KeyCode.Space) && Character.combination != 0)
         {
            Instantiate(Colba, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Hero.SetBool("Attack", true);
            StartCoroutine(waitAttack());
         }
        if (!Hero.GetBool("Attack"))
        {
            Rigidbody.velocity = new Vector2(moveX , moveY) *maxSpeed;
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

    IEnumerator waitAttack()
    {
        yield return new WaitForSeconds(0.5f);
        Hero.SetBool("Attack", false);
    }
}
