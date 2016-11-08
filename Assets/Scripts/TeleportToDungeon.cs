using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportToDungeon : MonoBehaviour {

    public string levelToLoad = "dungeon";

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
