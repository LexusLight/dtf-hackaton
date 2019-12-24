using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpell : MonoBehaviour
{
    public GameObject[] item;

    public void Spawn(GameObject obj)
    {
        Instantiate(item[0], new Vector2(obj.transform.position.x, obj.transform.position.y), Quaternion.identity);
    }
}
