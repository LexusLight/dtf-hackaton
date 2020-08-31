using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EenemyBullet : MonoBehaviour
{
    GameObject Player;
    Vector2 Vector;
    Rigidbody2D Rigi;
    public float speed = 1;
    void Start()
    {
        Rigi = gameObject.GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        Vector = new Vector2(Player.transform.position.x - gameObject.transform.position.x, Player.transform.position.y - gameObject.transform.position.y).normalized;
        Rigi.AddForce(Vector * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Character.hp--;
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Player.GetComponent<Character>().Damaged(gameObject,false));
        }

    }


}
