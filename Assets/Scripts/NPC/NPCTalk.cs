using UnityEngine;
using System.Collections;
using System;

public class NPCTalk : MonoBehaviour {

    public string questName;
    private string questDescription;

    private int talkingRegisterDistance = 5;

    private Quests allQuests = new Quests();

    private GameObject player;
    private GameObject questMark;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        questMark = GameObject.Find("QuestMark");
        questDescription = allQuests.GetQuestDescription(questName);
	}

    void Update() {
        //proof of concept
        if (IsQuestCompleted()) {
            questMark.SetActive(false);
        }
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(1)) {
            print("Right click on this object");
            if (Vector3.Distance(this.transform.position, player.transform.position) < talkingRegisterDistance) {
                print("You are close enough");
                if (!IsQuestCompleted()) {
                    print("Quest is not completed yet");
                } else {
                    print("Quest is completed");
                }
            }
        }
    }


    private bool IsQuestCompleted() {
        return player.GetComponent<PlayerQuests>().IsQuestCompleted(questName);
    }
}
