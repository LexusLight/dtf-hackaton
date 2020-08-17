using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MenuPoint : MonoBehaviour

{
    public int Id;
    public int countstars = 3;
    public string NameLvl;
    private Animator Image;
    GameObject LevelMananger;
    Text Text1;
    static public int idjstk = 0;
    private void Start()
    {
        Image = GetComponent<Animator>();
        LevelMananger = GameObject.Find("LevelMananger");
        Text1 = GameObject.Find("Text1").GetComponent<Text>();
    }
    private void OnMouseDown()
    {
        if (Id > Statistic.lvl) return;
        GameObject.Find("CountStars").GetComponent<Text>().text = GameObject.Find("LevelMananger").GetComponent<KeysAndStars>().starsinfo[Id].ToString() + "/" + countstars.ToString(); //Я лентяй и мне лень писать читаемый код
        Text1.text = NameLvl;
        Statistic.thislvl = Id;
        if (Image.GetBool("Choised")){
            LevelMananger.GetComponent<LoadLevel>().LoadFromMenu(Id);
        }
        GameObject[] Mass = GameObject.FindGameObjectsWithTag("Point");
        MenuCamera.pointX = transform.position.x;
        MenuCamera.pointY = transform.position.y;
        foreach (GameObject item in Mass)
        {
            item.GetComponent<Animator>().SetBool("Choised", false);
        }
        Image.SetBool("Choised", true);
    }



}
