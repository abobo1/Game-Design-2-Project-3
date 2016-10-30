using UnityEngine;
using System.Collections;

public class offlineMan : MonoBehaviour {
    public GameObject[] players;
    public Transform[] spawnLocations;
    public Vector3[] spawnPoints;
    public GameObject player;
	

    void Update()
    {
        if ( GetComponent<netMan>().gameMode == 1)
        {
            GetComponent<offlineMan>().enabled = false;
            return;
        }
        GameObject[] currentPlayer = GameObject.FindGameObjectsWithTag("Player");
        if (Application.loadedLevel == 1 && currentPlayer.Length == 0)
        {
            spawnPlayer(GameObject.Find("GameController").GetComponent<mainMenu>().playerId, 0);
        }
    }
    public void spawnPlayer(int playerNum, int location)
    {
        //player = (GameObject)Instantiate(players[playerNum], spawnLocations[location].position, spawnLocations[location].rotation);
        //player = (GameObject)Instantiate(players[playerNum]);
        player = (GameObject)Instantiate(players[playerNum]);
        player.transform.position = spawnPoints[location];
    }


}
