using System.Collections;
using System.Collections.Generic;
using System.Collections;
using Steamworks;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
    private static SteamManager _instance = null; // Экземпляр менеджера

    void Awake()
    {
        if (_instance == null) _instance = this;
        else if (_instance == this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        InitializeManager();
    }
    
    void InitializeManager()
    {
        Debug.Log("Steam: init");
        if (!SteamAPI.Init()) return;
        
        var name = SteamFriends.GetPersonaName();
        Debug.Log(name);
    }
}