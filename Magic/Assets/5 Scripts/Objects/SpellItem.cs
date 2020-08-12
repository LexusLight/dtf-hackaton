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
    public GameObject Table;
    private void Start()
    {
        Col = gameObject.GetComponent<BoxCollider2D>();
        Potion = GameObject.Find("Slot123");
        Image = Potion.GetComponent<Image>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for(int i = 0 ; i < 3; i++)
            {
                if (Character.combination[i] != 0) continue;
                Character.pointer = i;
                try{
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    Character.ObjIndex = Obj;
                    Character.combination[i] = Type;
                    switch (Character.combination[i])
                    {
                    case 1:                      
                        Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                        Image.color = Color.red;//255, 20, 94,1 уничтожение
                            break;
                    case 2:
                        Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                        Image.color = Color.green;//255, 20, 94,1 добавление
                            
                            break;
                    case 3:
                        Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                        Image.color = Color.magenta;//255, 20, 94,1 Превращение
                            
                            break;
                    case 4:
                        Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                        Image.color = Color.yellow;//255, 20, 94,1 Толкание

                            break;
                    case 5:
                        Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                        Image.color = new Color(1f, 0.6f, 0f);
                            //Image.color = new Color(255, 108, 0); //255, 20, 94,1 Магнит
                            
                            break;
                    case 6:
                        Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                        Image.color = new Color(0f, 0.7f, 1f);
                        
                            break;
                    case 0:
                        Image.color = Color.white;
                        break;
                    }
                    GameObject.Find("Pointer").GetComponent<Text>().text = (Character.pointer + 1).ToString();
                }
            catch { }
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            try { StartCoroutine(DestroyTable()); } catch { }
                break;
            }
            
        }
    }

    public static void Check()
    {
        Image.color = Color.white;
    }

    public static void PointerColor()
    {
        switch (Character.combination[Character.pointer])
        {
            case 1:
                Image.color = Color.red;//255, 20, 94,1 уничтожение
                Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                break;
            case 2:
                Image.color = Color.green;//255, 20, 94,1 добавление
                Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                break;
            case 3:
                Image.color = Color.magenta;//255, 20, 94,1 Превращение
                Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                break;
            case 4:
                Image.color = Color.yellow;//255, 20, 94,1 Толкание
                Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                break;
            case 5:
                Image.color = new Color(1f, 0.6f, 0f);
                Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                //Image.color = new Color(255, 108, 0); //255, 20, 94,1 Магнит
                break;
            case 6:
                Image.color = new Color(0f, 0.7f, 1f);
                Potion.GetComponent<Animator>().SetInteger("Slot", 1);
                break;
            case 0:
                Image.color = Color.white;
                Potion.GetComponent<Animator>().SetInteger("Slot", 0);
                break;
        }
    }

    IEnumerator DestroyTable()
    {
        gameObject.tag = "Untagged";
        try
        {
            SpriteRenderer Ren = Table.GetComponent<SpriteRenderer>();
            for (float bright = 1; bright > 0; bright -= Time.deltaTime)
            {
                Ren.color = new Color(1, 1, 1, bright);
                yield return new WaitForSeconds(0.01f);
            }
            try { Destroy(Table); } catch { }
        }
        finally
        {  }
        Destroy(gameObject);
    }
}
