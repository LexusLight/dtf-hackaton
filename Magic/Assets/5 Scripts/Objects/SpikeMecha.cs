using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMecha : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Skeleton>().Die();
        }
        if (collision.gameObject.tag == "Player")
        {
            Vector2 vel = new Vector2(gameObject.transform.position.x - collision.gameObject.transform.position.x, gameObject.transform.position.y - collision.gameObject.transform.position.y);
            Character.hp--;
            StartCoroutine(collision.gameObject.GetComponent<Character>().Damaged());
            collision.gameObject.GetComponent<moveScript>().punch(vel);
        }
    }

}
