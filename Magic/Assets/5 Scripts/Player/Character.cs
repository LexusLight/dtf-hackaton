using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static int[] combination = { 0, 0, 0 };
    public static int pointer = 0;
    public int maxhp = 3;
    public static int hp = 3;
    public GameObject[] Objct;
    bool lose = false;
    Animator hpObj;
    Animator anim;
    SpriteRenderer rend;
    GameObject cringe;
    GameObject great;

    public static Vector2 ThrowVector;
    public static Vector2 LineThrowVector;
    public static int ObjIndex;
    public static bool IsAttackSpell = false;

    public int stars = 0;
    public int keys = 0;

    private void Awake()
    {
        hpObj  = GameObject.Find("HpTracker").GetComponent<Animator>();
        anim  = gameObject.GetComponent<Animator>();
        rend = gameObject.GetComponent<SpriteRenderer>();
        great = GameObject.Find("Great");
        cringe = GameObject.Find("Cringe");
        great.SetActive(false);
        cringe.SetActive(false);
    }

    private void Update()
    {
        if (combination[pointer] > 6) IsAttackSpell = true; else IsAttackSpell = false;
        hpObj.SetInteger("Hp", hp);
        
    }
    private void Start()
    {
        hp = maxhp;
    }

    public IEnumerator Damaged(GameObject obj = null)
    {
        if (hp < 1 && !lose)
        {
            StartCoroutine(YouLoseLevel());
            lose = true;
        }
        if (lose == true)
        {
            transform.Rotate(0, 0, 90f);
        }
        gameObject.GetComponent<moveScript>().punch();
        gameObject.GetComponent<moveScript>().stop = true;
        yield return new WaitForSeconds(0.2f);
        rend.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.2f);
        rend.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.2f);
        rend.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        rend.color = new Color(1f, 1f, 1f, 1f);
        gameObject.GetComponent<moveScript>().stop =(lose == false) ? false : true;
        if (obj != null)
        {
            Destroy(obj);
        }

        //SceneManager.LoadScene(NumScene);//внимание
    }

    public IEnumerator YouLoseLevel()
    {
        anim.speed = 0;
        lose = true;
        yield return new WaitForSeconds(2f);
        Image image = GameObject.Find("Imagelvl").GetComponent<Image>();
        cringe.SetActive(true);
        

        for (float bright = 0; bright < 1; bright += Time.deltaTime * 2)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }
        //SceneManager.LoadScene(NumScene);//внимание
    }

    public IEnumerator NextLevel1()
    {

        Image image = GameObject.Find("Imagelvl").GetComponent<Image>();
        great.SetActive(true);
        GameObject.Find("StarsText").GetComponent<Text>().text = "x" + stars;
        GameObject.Find("KeysText").GetComponent<Text>().text = "x" + keys;

        for (float bright = 0; bright < 1; bright += Time.deltaTime * 2)
        {
            image.color = new Color(0, 0, 0, bright);
            yield return new WaitForSeconds(0.005f);
        }


        if (PlayerPrefs.GetInt("lvl") < 1)
        {
            PlayerPrefs.SetInt("lvl", 2);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt("lvl") == Statistic.LvlDone)
        {
            PlayerPrefs.SetInt("lvl", Statistic.LvlDone + 1);
            PlayerPrefs.Save();
        }
        //SceneManager.LoadScene(NumScene);//внимание
    }
}
