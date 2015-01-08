using UnityEngine;
using System.Collections;

public class TopDownCameraFollow : MonoBehaviour
{

    //public Transform target;
    public float followSpeed = 3;
    private bool playerExists = false;
    private GameObject targetPlayer;

	void Start () 
    {
        SpawnPlayer.PlayerSpawned += SpawnPlayer_PlayerSpawned;
	}

    void SpawnPlayer_PlayerSpawned(GameObject player)
    {
        targetPlayer = player;
        playerExists = true;
    }	
	
	void Update () {
        if (playerExists)
        {
            var newPosition = new Vector3(targetPlayer.transform.position.x, targetPlayer.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * followSpeed); 
        }
	}
}
