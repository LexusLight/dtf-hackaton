using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysAndStars : MonoBehaviour
{
    //уровни считаем с 2
    public GameObject KeysObj;
    public static int Stars;
    public static int Keys;
    const int numLevels = 20;
    const int numKeys = 10;
    public int[] keyinfo = new int[numKeys];
    public int[] starsinfo = new int[numLevels+2];
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        for (int i = 2; i < numKeys; i++)
        {                                        //Если есть в базе   и   должен быть на карте то возвращаем 1 => потом отрисовываем иначе ключа там нет.
            keyinfo[i] = (PlayerPrefs.GetInt("key" + i.ToString()) == 1 && keyinfo[i]==1) ? 1 : 0; //Если значение пустое, то мы кладём 1(ключ не подобран) иначе берём 1 или 2
        }
        for (int i = 2; i < starsinfo.Length; i++)
        {
            starsinfo[i] = PlayerPrefs.GetInt("stars" + i.ToString());
        }
    }
}
