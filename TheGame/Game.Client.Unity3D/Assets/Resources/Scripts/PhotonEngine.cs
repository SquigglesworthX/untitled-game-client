using UnityEngine;
using System.Collections;
using TheGame.Client.Engine;
using System;
using ExitGames.Client.Photon;
using System.Collections.Generic;

public class PhotonEngine : MonoBehaviour
{
    private Game _engine;

    private static PhotonEngine _instance;
    public static PhotonEngine Instance
    {
        get { return PhotonEngine._instance; }
    }

    public void Awake()
    {
        _instance = this;
    }

    public void Start()
    {
        Application.runInBackground = true;
        DontDestroyOnLoad(this);
        Initialize();
    }

    void Initialize() 
    {
        _engine = new Game();
        _engine.Logger += (msg) =>
        {
            Debug.Log(msg);
        };
        _engine.Initialize();
    }
	
	void Update () 
    {
        _engine.Update();
	}    

    //void OnGUI()
    //{
    //    GUI.Box(new Rect(5, 5, 150, 50), "");
    //    GUI.Label(new Rect(10, 10, 150, 20), "Connection Status");
    //    GUI.Label(new Rect(10, 30, 150, 20), _engine.ConnectionStatus);
    //}
    
    public void OnApplicationQuit()
    {
        try
        {
            _engine.SetDisconnected();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

   
}
