using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPoint : MonoBehaviour

{
    public int Id;
    private Animator Image;
    public GameObject LevelMananger;
    private void Start()
    {
        Image = GetComponent<Animator>();
        LevelMananger = GameObject.Find("LevelMananger");
    }
    private void OnMouseDown()
    {
        if (Id > Statistic.lvl) return;
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
