﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
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
            Destroy(gameObject);
        }

    }
}
