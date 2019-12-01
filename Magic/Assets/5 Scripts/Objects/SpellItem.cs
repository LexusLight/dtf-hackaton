using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpellItem : MonoBehaviour
{
    BoxCollider2D Col;
    static GameObject Potion;
    static Image Image;
    public int Obj;
    public int Type = 1;
    private void Start()
    {
        Col = gameObject.GetComponent<BoxCollider2D>();
        Potion = GameObject.FindGameObjectWithTag("Potion");
        Image = Potion.GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Character.combination == 0)
        {
            Character.ObjIndex = Obj;
            Character.combination *= 1;//0;
            Character.combination = Type;
            switch (Character.combination)
            {
                case 1:
                    Image.color = Color.red;//255, 20, 94,1 уничтожение
                    break;
                case 2:
                    Image.color = Color.green;//255, 20, 94,1 добавление
                    break;
                case 3:
                    Image.color = Color.magenta;//255, 20, 94,1 Превращение
                    break;
                case 4:
                    Image.color = Color.yellow;//255, 20, 94,1 Толкание
                    break;
                case 0:
                    Image.color = Color.white;
                    break;
            }
            Potion.GetComponent<Animator>().SetBool("SlotYes", true);
            Destroy(gameObject);
        }
    }
    public static void Check()
    {
        Image.color = Color.white;
    }
}
