using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MenuPoint : MonoBehaviour

{
    public int Id;
    public string NameLvl;
    private Animator Image;
    GameObject LevelMananger;
    Text Text1;
    private void Start()
    {
        Image = GetComponent<Animator>();
        LevelMananger = GameObject.Find("LevelMananger");
        Text1 = GameObject.Find("Text1").GetComponent<Text>();
    }
    private void OnMouseDown()
    {
        if (Id > Statistic.lvl) return;
        Text1.text = NameLvl;
        if (Image.GetBool("Choised")){
            LevelMananger.GetComponent<LoadLevel>().Load(Id);
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
