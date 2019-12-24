using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int type = 1;
    public GameObject Treasure;
    public GameObject Bullet;
    public float speed = 1;
    private int vector = 5;
    private Animator Anim;
    private BoxCollider2D Col;
    private Rigidbody2D Rigi;
    private float x;
    private float y;
    private bool Attack = false;
    private bool canChange = true;
    bool CanWalk = true;
    GameObject Player;

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        Col = gameObject.GetComponent<BoxCollider2D>();
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Wait());
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canChange)
        {
            canChange = false;
            StartCoroutine(ChangeV());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canChange = true;
    }

    void Update()
    {
        if((Vector2.Distance(gameObject.transform.position, Player.transform.position) < 5)&& !Attack)
        {
            CanWalk = false;
            Rigi.velocity = Vector2.zero;
            Attack = true;
            Anim.SetBool("Attack", true);
            Instantiate(Bullet, transform.position, Quaternion.identity);
            Anim.speed = 0;
            StartCoroutine(WaitAttack());
        }


        if (CanWalk)
        {
            Anim.speed = 1;
            switch (vector)
                    {
                case 0:
                    Anim.SetInteger("Vector", vector);
                    Anim.speed = 1;
                    x = -1;
                    y = 0;
                    break;
                case 1:
                    Anim.SetInteger("Vector", vector);
                    Anim.speed = 1;
                    x = 0;
                    y = 1;
                    break;
                case 2:
                    Anim.SetInteger("Vector", vector);
                    Anim.speed = 1;
                    x = 1;
                    y = 0;
                    break;
                case 3:
                    Anim.SetInteger("Vector", vector);
                    Anim.speed = 1;
                    x = 0;
                    y = -1;
                    break;
                case 4:
                    Anim.SetInteger("Vector", vector);
                    Anim.speed = 0;
                    x = 0;
                    y = 0;
                    break;
                
                    }
            Rigi.velocity = new Vector2(x, y).normalized * speed;
        }        

        
    }

    IEnumerator Wait() {
        if(type == 1)
        {
            vector = Random.Range(0, 4);
        }
        if (type == 2)
        {
            vector = (vector < 2) ? 2 : 0;
        }
        if (type == 3)
        {
            vector = (vector < 2) ? 3 : 1;
        }
        yield return new WaitForSeconds(10f);
        StartCoroutine(Wait());
    }

    IEnumerator WaitAttack()
    {
        Anim.speed = 0;
        yield return new WaitForSeconds(1f);
        Anim.SetBool("Attack", false);
        yield return new WaitForSeconds(2f);
        Attack = false;
        CanWalk = true;
    }

    IEnumerator ChangeV()
    {
        yield return new WaitForSeconds(0.3f);
        StopAllCoroutines();
        StartCoroutine(Wait());
        Attack = !true;
        CanWalk = true;
    }

    void Die()
    {
        Instantiate(Treasure,gameObject.transform);
    }
}
