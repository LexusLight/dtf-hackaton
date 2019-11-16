using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    public float maxSpeed = 1f; //Максимальная скорость передвижения
    Animator Hero;
    Vector2 Direction;
    Rigidbody2D Rigi;
    Animator Potion;
    int Vector;

    void Start()
    {
        Hero = GameObject.Find("Player").GetComponent<Animator>();
        Potion = GameObject.FindGameObjectWithTag("Potion").GetComponent<Animator>();
        Rigi = GetComponent<Rigidbody2D>();
        Potion.SetBool("SlotYes", false);
        switch (Hero.GetInteger("Vector"))
        {
            case 1:
                Direction = new Vector2(-1f, 0).normalized;
                break;
            case 2:
                Direction = new Vector2(0, 1f).normalized;
                break;
            case 3:
                Direction = new Vector2(1f, 0).normalized;
                break;
            case 4:
                Direction = new Vector2(0, -1f).normalized;
                break;
        }
    }

    void Update()
    {
        Rigi.velocity = Direction * maxSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }


}
