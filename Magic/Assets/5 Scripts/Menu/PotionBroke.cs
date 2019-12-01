using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBroke : MonoBehaviour
{
public void Broke(GameObject X)
    {
        X.GetComponent<Animator>().SetBool("Broke", true);
    }
}
