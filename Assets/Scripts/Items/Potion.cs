using UnityEngine;
using System.Collections;

public class Potion : MonoBehaviour {

    public int size;

    public int numberOwned = 2;

    private int maxHeal;
    private GameObject player;
    private playerStat playerStat;

    // Use this for initialization
    void Start () {
        maxHeal = size;
        player = GameObject.FindGameObjectWithTag("Player");
        playerStat = player.GetComponent<playerStat>();
	}

    public void UsePotion() {
        if (numberOwned > 0) {
            playerStat.AddHealth(maxHeal);
            numberOwned--;
        }
    }


}
