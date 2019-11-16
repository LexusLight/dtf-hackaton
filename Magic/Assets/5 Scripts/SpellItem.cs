using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellItem : MonoBehaviour
{
    BoxCollider2D Col;
    Animator Potion;
    public int Type = 1;
    private void Start()
    {
        Col = gameObject.GetComponent<BoxCollider2D>();
        Potion = GameObject.FindGameObjectWithTag("Potion").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Character.combination *= 10;
            Character.combination += Type;
            print(Character.combination);
            Potion.SetBool("SlotYes", true);
            Destroy(gameObject);
        }
    }
}
