﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOrderOnly : MonoBehaviour
{
    public int x = 2;
    public int y = 5;
    private void Update()
    {
        if (transform.position.y > GameObject.FindGameObjectWithTag("Player").transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = x;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = y;
        }
    }
}