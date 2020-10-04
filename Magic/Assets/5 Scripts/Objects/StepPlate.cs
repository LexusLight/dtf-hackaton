﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPlate : MonoBehaviour
{

    public GameObject[] Spikes;
    public GameObject[] Objects;
    private byte count = 0;
    private Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Block")
        {
            count++;
            if (count > 0) anim.SetBool("Active", true);
            foreach ( GameObject obj in Objects){
                obj.SetActive(false);
            }
            foreach (GameObject spike in Spikes)
            {
                spike.GetComponent<Animator>().SetBool("Active", false);
                spike.GetComponent<Collider2D>().isTrigger = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Block")
        {
            count--;
            if (count <= 0)
            {
                anim.SetBool("Active", false);
                foreach (GameObject obj in Objects)
                {
                    obj.SetActive(false);
                }
                foreach (GameObject spike in Spikes)
                {
                    spike.GetComponent<Animator>().SetBool("Active", true);
                    spike.GetComponent<Collider2D>().isTrigger = false;
                }
            }
        }

    }
}
