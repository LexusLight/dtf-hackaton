using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPlate : MonoBehaviour
{

    public GameObject[] Spikes;
    public GameObject[] Objects;
    private byte count = 0;
    private Animator anim;
    private BoxCollider2D col;
    public bool deactivate = false;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<BoxCollider2D>();
        if (deactivate)
            foreach (GameObject spike in Spikes)
            {
                spike.GetComponent<Animator>().SetBool("Active", false);
                //spike.GetComponent<Collider2D>().isTrigger = true;
                spike.GetComponent<Collider2D>().enabled = false;
            }
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
                //spike.GetComponent<Collider2D>().isTrigger = true;
                spike.GetComponent<Collider2D>().enabled = false;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Block")
        {
            count--;
            if (count <= 0 && (collision.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic))
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
                    spike.GetComponent<Collider2D>().enabled = true;
                }
            }
        }

    }
}
