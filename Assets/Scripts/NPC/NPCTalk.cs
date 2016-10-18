using UnityEngine;
using System.Collections;
using System;

public class NPCTalk : MonoBehaviour {

    public String questName;

    private int talkingRegisterDistance = 5;

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(1)) {
            print("Right click on this object");
            if (Vector3.Distance(this.transform.position, player.transform.position) < talkingRegisterDistance) {
                print("You are close enough");
            }
        }
    }
}
