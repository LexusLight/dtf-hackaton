using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "MechaSpike")
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "MechaSpike")
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
