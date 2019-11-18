using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spell : MonoBehaviour
{
    public float maxSpeed = 1f; //Максимальная скорость передвижения
    Animator Hero;
    Vector2 Direction;
    Rigidbody2D Rigi;
    Animator Potion;
    SpriteRenderer PotionImage;
    Character Ch;
    int TypePotion;
    int Vector;
    bool CanDo = true;

    void Start()
    {
        Ch = GameObject.Find("Player").GetComponent<Character>();
        TypePotion = Character.combination;
        Character.combination = 0;
        SpellItem.Check();
        Hero = GameObject.Find("Player").GetComponent<Animator>();
        Potion = GameObject.FindGameObjectWithTag("Potion").GetComponent<Animator>();
        PotionImage = GetComponent<SpriteRenderer>();
        switch (TypePotion)
        {
            case 1:
                PotionImage.color = Color.red;//255, 20, 94,1 уничтожение
                break;
            case 2:
                PotionImage.color = Color.green;//255, 20, 94,1 добавление
                break;
            case 3:
                PotionImage.color = Color.magenta;//255, 20, 94,1 Превращение
                break;
            case 4:
                PotionImage.color = Color.yellow;//255, 20, 94,1 Толкание
                break;
        }
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Block") && CanDo)
        {
            gameObject.GetComponent<Animator>().SetBool("Broke",true);
            CanDo = false;
            switch (TypePotion)
            {
                case 1://уничтожение
                    Destroy(collision.gameObject);
                    StartCoroutine(WaitDestroy());
                    break;
                case 2://добавление

                    break;
                case 3://превращение
                    Instantiate(GameObject.Find("Player").GetComponent<Character>().Objct[0], collision.gameObject.transform.position, Quaternion.identity);
                    Destroy(collision.gameObject);
                    StartCoroutine(WaitDestroy());
                    break;                   
                case 4://толкание
                    collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Direction * maxSpeed*10, ForceMode2D.Impulse);
                    StartCoroutine(WaitStatic(collision));
                    break;
            }
        }
    }

    IEnumerator WaitStatic(Collider2D Col) 
    {
        StartCoroutine(WaitDestroy());
        yield return new WaitForSeconds(1f);
        Col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Col.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
