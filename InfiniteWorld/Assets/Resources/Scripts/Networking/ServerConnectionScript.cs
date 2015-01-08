using UnityEngine;
using System.Collections;
using System;

public class ServerConnectionScript : MonoBehaviour {

    public delegate void JoinAction();
    public static event JoinAction OnRoomJoined;

	// Use this for initialization
	void Start () 
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
		Debug.Log("Connected to Photon network.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private const string roomName = "RoomName";
	private RoomInfo[] roomsList;

	// not efficient, do not use
	void OnGUI()
	{
		if (!PhotonNetwork.connected)
		{
			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		}
		else if (PhotonNetwork.room == null)
		{
			// Create Room
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
            {
                RoomOptions options = new RoomOptions()
                {
                    isOpen = true,
                    isVisible = true,
                    maxPlayers = 5
                };
                
                PhotonNetwork.CreateRoom(roomName + Guid.NewGuid().ToString("N"), options, TypedLobby.Default);
            }
			// Join Room
			if (roomsList != null)
			{
				for (int i = 0; i < roomsList.Length; i++)
				{
					if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + roomsList[i].name))
						PhotonNetwork.JoinRoom(roomsList[i].name);
				}
			}
		}
	}
	
	void OnReceivedRoomListUpdate()
	{
		roomsList = PhotonNetwork.GetRoomList();
	}
	void OnJoinedRoom()
	{
		Debug.Log("Connected to Room");
        // Spawn player
        OnRoomJoined();
        //PhotonNetwork.Instantiate("Prefabs/Characters/" + playerPrefab.name, Vector3.zero, Quaternion.identity, 0);
	}
}
