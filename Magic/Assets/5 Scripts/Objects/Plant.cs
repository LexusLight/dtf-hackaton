using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    Animator Pl;
    BoxCollider2D Col;
    void Start()
    {
        Pl = gameObject.GetComponent<Animator>();
        Col = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meat")
        {
            Pl.SetBool("Hungry", false);
            Col.isTrigger = true;
            Destroy(collision.gameObject);
        }
    }

}
