using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class NPCTalk : MonoBehaviour {

    public string questName;
    private string questDescription;

    private int talkingRegisterDistance = 5;

    private Quests allQuests = new Quests();

    private GameObject player;
    private GameObject questMark;
    private GameObject questPanel,replyPanel;
    public Text questTitleText;
    public Text questDescriptionText;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        questMark = GameObject.Find("QuestMark");
        questPanel = GameObject.Find("QuestPanel");
        questPanel.SetActive(false);
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
                    //if (player.GetComponent<PlayerQuests>().)
                    print("Quest is not completed yet");
                    questTitleText.text = questName;
                    questDescriptionText.text = questDescription;
                    questPanel.SetActive(true);
                }
                else {
                    print("Quest is completed");
                }
            }
        }
    }

    public void AcceptQuest() {
        player.GetComponent<PlayerQuests>().SetQuestStatus(questName, "Active");
    }


    private bool IsQuestCompleted() {
        return player.GetComponent<PlayerQuests>().IsQuestCompleted(questName);
    }
}
