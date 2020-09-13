using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NextLevelFlag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Character.combination = new int[3];
            //Character.hp = Character.hp;
            StartCoroutine(collision.gameObject.GetComponent<Character>().NextLevel1());
        }
    }

    private void OnDestroy()
    {
        GameObject.Find("Player").GetComponent<Character>().noflag = true;
        
    }

}
