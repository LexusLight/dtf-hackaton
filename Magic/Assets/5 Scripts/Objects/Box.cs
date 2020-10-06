using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "MechaSpike")
        {
            print("ffdsfsf");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
            
    }
}
