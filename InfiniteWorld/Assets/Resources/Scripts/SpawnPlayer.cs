using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

    public GameObject playerPrefab;   

    public delegate void SpawnedAction(GameObject player);
    public static event SpawnedAction PlayerSpawned;

	void Start () 
    {
        ServerConnectionScript.OnRoomJoined += ServerConnectionScript_OnRoomJoined;
	}

    
    void ServerConnectionScript_OnRoomJoined()
    {
        var player = PhotonNetwork.Instantiate("Prefabs/Characters/" + playerPrefab.name, Vector3.zero, Quaternion.identity, 0);
        player.transform.parent = gameObject.transform;        
        PlayerSpawned(player);
    }
}
