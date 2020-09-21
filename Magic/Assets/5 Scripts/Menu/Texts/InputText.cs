using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    public int string_num = 0;
    public string str;
    public bool timer = false;
    Text text;

    void Awake()
    {
        text = gameObject.GetComponent<Text>();
        str = (Texts.Language == 1) ? Texts.Ru[string_num] : Texts.Eng[string_num];
        if(!timer) text.text = str;
    }

    public void OnEnable()
    {
        if (timer)
        {
            StartCoroutine(InputWithTime(str));
        }
    }

    public void OnDisable()
    {
        text.text = "";
    }

    IEnumerator InputWithTime(string str)
    {
        text.text = "";
        for (int i=0; i<str.Length; i++)
        {
            yield return new WaitForSeconds(0.05f);
            text.text = text.text + str[i];
        }
        
    }
}
