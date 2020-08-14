using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    GameObject Player;
    Rigidbody2D Rigi;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        Rigi = Player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Skeleton>().Die();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Character.hp--;
            StartCoroutine(Player.GetComponent<Character>().Damaged(gameObject));
        }

    }
}
