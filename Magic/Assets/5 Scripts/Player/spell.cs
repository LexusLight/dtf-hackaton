using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spell : MonoBehaviour
{
    public float maxSpeed = 1f; //Максимальная скорость передвижения
    Animator Hero;
    Vector2 Direction;
    public static Vector2 LineDirection;
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
        TypePotion = Character.combination[Character.pointer];
        Character.combination[Character.pointer] = 0;
        SpellItem.Check();
        Hero = GameObject.Find("Player").GetComponent<Animator>();
        Potion = GameObject.Find("Slot123").GetComponent<Animator>();
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
            case 5:
                PotionImage.color = new Color(1f, 0.6f, 0f);
                break;
            case 6:
                PotionImage.color = new Color(0f, 0.7f, 1f);
                break;

        }
        Rigi = GetComponent<Rigidbody2D>();
        Potion.SetInteger("Slot", 0);

        switch (Hero.GetInteger("Vector"))
        {
            case 1:
                Character.LineThrowVector = new Vector2(-1, 0).normalized;
                break;
            case 2:
                Character.LineThrowVector = new Vector2(0, 1).normalized;
                break;
            case 3:
                Character.LineThrowVector = new Vector2(1, 0).normalized;
                break;
            case 4:
                Character.LineThrowVector = new Vector2(0, -1).normalized;
                break;
        }

        Direction = Character.ThrowVector;
        LineDirection = Character.LineThrowVector;
        if (!Character.IsAttackSpell) Direction = LineDirection;
    }

    void Update()
    {
        Rigi.velocity = Direction * maxSpeed;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Block")|| collision.CompareTag("Meat") || collision.CompareTag("Potion")) && CanDo)
        {
            BlockTrigger(TypePotion, collision);
        }
        if (collision.CompareTag("Enemy") && CanDo)
        {
            EnemyTrigger(TypePotion, collision);
            print(1);
        }
    }

    private void BlockTrigger(int TypePotion, Collider2D collision) //Если мы сталкиваемся с блоком
    {
        gameObject.GetComponent<Animator>().SetBool("Broke", true);
        gameObject.GetComponent<Collider2D>().enabled = false;
        CanDo = false;
        switch (TypePotion)
        {
            case 1://уничтожение
                Destroy(collision.gameObject);
                StartCoroutine(WaitDestroy());
                break;
            case 2://добавление
                //Instantiate(GameObject.Find("Player").GetComponent<Character>().Objct[0], collision.gameObject.transform.position, Quaternion.identity);
                //Destroy(collision.gameObject);
                //StartCoroutine(WaitDestroy()); это превращение
                break;
            case 3://смена местами
                Vector2 pos1 = GameObject.Find("Player").transform.position;
                Vector2 pos2 = collision.transform.position;
                GameObject.Find("Player").transform.position = pos2;
                collision.transform.position = pos1;
                break;
            case 4://толкание
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                collision.gameObject.GetComponent<Rigidbody2D>().drag = 1;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(LineDirection * maxSpeed * 10, ForceMode2D.Impulse);
                StartCoroutine(WaitStatic(collision));
                break;
            case 5://магнит
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                collision.gameObject.GetComponent<Rigidbody2D>().drag = 1;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-LineDirection * maxSpeed * 10, ForceMode2D.Impulse);
                StartCoroutine(WaitStatic(collision));
                break;
            case 6://призрак
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(collision.gameObject.GetComponent<SpriteRenderer>().color.r, collision.gameObject.GetComponent<SpriteRenderer>().color.g, collision.gameObject.GetComponent<SpriteRenderer>().color.b, 0.5f);
                collision.gameObject.tag = "Ghost";
                break;
        }
    }

    private void EnemyTrigger(int TypePotion, Collider2D collision) //если мы сталкиваемся со врагом ДОПИЛИТЬ!
    {
        gameObject.GetComponent<Animator>().SetBool("Broke", true);
        gameObject.GetComponent<Collider2D>().enabled = false;
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
                collision.gameObject.GetComponent<Skeleton>().enabled = false;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                collision.gameObject.GetComponent<Rigidbody2D>().mass = 10;
                collision.gameObject.GetComponent<Rigidbody2D>().drag = 1;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(LineDirection * maxSpeed * 10, ForceMode2D.Impulse);
                StartCoroutine(WaitStop(collision));
                break;
            case 5://магнит
                collision.gameObject.GetComponent<Skeleton>().enabled = false;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                collision.gameObject.GetComponent<Rigidbody2D>().mass = 10;
                collision.gameObject.GetComponent<Rigidbody2D>().drag = 1;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-LineDirection * maxSpeed * 10, ForceMode2D.Impulse);
                StartCoroutine(WaitStop(collision));
                break;
            case 6://магнит
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(collision.gameObject.GetComponent<SpriteRenderer>().color.r, collision.gameObject.GetComponent<SpriteRenderer>().color.g, collision.gameObject.GetComponent<SpriteRenderer>().color.b, 0.5f);
                collision.gameObject.tag = "Ghost";
                break;
        }
    }

    IEnumerator WaitStatic(Collider2D Col) 
    {
        StartCoroutine(WaitDestroy());
        yield return new WaitForSeconds(0.7f);
        Col.gameObject.GetComponent<Rigidbody2D>().drag = 7;
        Col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Col.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    IEnumerator WaitStop(Collider2D Col)
    {
        StartCoroutine(WaitDestroy());
        yield return new WaitForSeconds(0.7f);
        Col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Col.gameObject.GetComponent<Rigidbody2D>().mass = 1000;
        Col.gameObject.GetComponent<Skeleton>().enabled = true;
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
