using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class NPCTalk : MonoBehaviour {

    public string questName;
    private string questDescription;
    private string replyDescription;
    private string finishedReply;

    private bool readyToTurnIn;
    private bool isQuestReady;

    private int talkingRegisterDistance = 5;

    private Quests allQuests = new Quests();

    public GameObject player;
    public GameObject questMark,questMarkPrefab;
    public GameObject questPanel,replyPanel;
    public Text questTitleText;
    public Text questDescriptionText;
    public Text replyText;

	// Use this for initialization
	void Start () {
        Vector3 pos = new Vector3(gameObject.transform.position.x, 2, gameObject.transform.position.z);
        questMark = (GameObject)Instantiate(questMarkPrefab,gameObject.transform);
        questMark.transform.position = pos;

        questDescription = allQuests.GetQuestDescription(questName);
        replyDescription = allQuests.GetReply(questName);
        finishedReply = allQuests.GetFinishedReply(questName);
        readyToTurnIn = false;
        isQuestReady = false;
    }
    void OnAwake() {
        questPanel.SetActive(false);
        replyPanel.SetActive(false);
    }

    void Update() {

    }

    void LateUpdate() {

        if (IsQuestReadyToPickUp()) {
            isQuestReady = true;
            if (IsQuestReadyToTurnIn()) {
                readyToTurnIn = true;
                //change questMark to show ready to turn in
            }
        }

    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(1) && questMark) {
            print("Right click on this object");
            if (Vector3.Distance(this.transform.position, player.transform.position) < talkingRegisterDistance) {
                print("You are close enough");

                //test

                //Debug.Log(player.GetComponent<PlayerQuests>().GetQuestStatus(questName));
                //end test
                if (isQuestReady) {
                    if (!IsQuestCompleted()) {
                        if (player.GetComponent<PlayerQuests>().GetQuestStatus(questName) != "Active") {
                            //Quest not completed and player hasn't accepted it yet
                            print("Quest is not completed yet");
                            questTitleText.text = questName;
                            questDescriptionText.text = questDescription;
                            questPanel.SetActive(true);
                            questMark.SetActive(false);
                        } else {
                            //Quest not completed but player already accepted it yet
                            if (readyToTurnIn) {
                                //Quest not completed, player has requirements for quest to be completed, ready to turn in
                                questDescriptionText.text = finishedReply;
                                questPanel.SetActive(true);
                                replyPanel.SetActive(false);
                            } else {
                                //Quest still in progress
                                replyText.text = replyDescription;
                                questPanel.SetActive(false);
                                replyPanel.SetActive(true);
                            }
                        }
                    } else {
                        //Quest already finished
                    }
                } else {
                    //Quest isn't ready to be picked up. Maybe some form of "no quest at this time"
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

    private bool IsQuestReadyToTurnIn() {
        int numberNeeded = allQuests.GetNumberOfItemsNeeded(questName);
        string itemName = allQuests.GetItemNeeded(questName);
        //Check if player has numberNeeded of itemName in inventory
            //if true
                //return true
            //else
                return false;
    }

    private bool IsQuestReadyToPickUp() {
        int requiredLevel = allQuests.GetLevelRequired(questName);
        string questRequired = allQuests.GetQuestRequired(questName);
        bool requiredQuestCompleted = true;
        if (questRequired != "") {
            requiredQuestCompleted = player.GetComponent<PlayerQuests>().IsQuestCompleted(questRequired);
        }
        //if player level >= requiredLevel && requiredQuestCompleted
            return true;
        //else
            //return false
    }
}
