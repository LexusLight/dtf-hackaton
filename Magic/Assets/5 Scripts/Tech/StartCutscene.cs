using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public GameObject Director;
    public GameObject[] Activate;
    public void StartDirector()
    {
        foreach (GameObject o in Activate) o.SetActive(true);
        Director.SetActive(true);
        Destroy(this);
    }
}
