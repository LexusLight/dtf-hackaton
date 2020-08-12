using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysAndStars : MonoBehaviour
{
    //уровни считаем с 2
    public GameObject KeysObj;
    public GameObject StarsObj;
    public static int Stars;
    public static int Keys;
    public static int numLevels = 20;
    const int numKeys = 10;
    public int[] keyinfo = new int[numKeys];
    public int[] starsinfo = new int[numLevels+2];
    private void Awake()
    {
        for (int i = 2; i < numKeys; i++)
        {
            keyinfo[i] = (PlayerPrefs.GetInt("key" + i.ToString()) == 0) ? 1 : PlayerPrefs.GetInt("lvl" + i.ToString()); //Если значение пустое, то мы кладём 1(ключ не подобран) иначе берём 1 или 2
        }
        for (int i = 2; i < starsinfo.Length; i++)
        {
            starsinfo[i] = PlayerPrefs.GetInt("stars" + i.ToString());
        }
    }
}
