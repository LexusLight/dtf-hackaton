using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static int[] combination = { 0, 0, 0 };
    public static int pointer = 0;
    public int maxhp = 3;
    public static int hp = 3;
    public GameObject[] Objct;

    public static Vector2 ThrowVector;
    public static Vector2 LineThrowVector;
    public static int ObjIndex;
    public static bool IsAttackSpell = false;

    private void Update()
    {
        if (combination[pointer] > 6) IsAttackSpell = true; else IsAttackSpell = false;
        GameObject.Find("HpTracker").GetComponent<Animator>().SetInteger("Hp", hp);
    }
    private void Start()
    {
        hp = maxhp;
    }
}
