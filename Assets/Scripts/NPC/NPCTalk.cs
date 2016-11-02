﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class NPCTalk : MonoBehaviour {

    public string questToGive;
    public string questToComplete;
    private string questDescription;
    private string replyDescription;
    private string notFinishedReply;
    private string finishedReply;

    private bool doIHaveAQuestToGive;
    private bool doIHaveAQuestToComplete;

    private int talkingRegisterDistance = 5;

    private int currentState = 1;

    private Quests allQuests = new Quests();

    private PlayerQuests playerQuests;

    private GameObject questMark;

    public GameObject player;
    public GameObject questMarkPrefab;
    public GameObject questPanel;
    public GameObject closeButton;
    public GameObject acceptButton;
    public GameObject completeButton;
    public Text questTitleText;
    public Text questDescriptionText;

	// Use this for initialization
	void Start () {
        Vector3 pos = new Vector3(gameObject.transform.position.x, 2, gameObject.transform.position.z);
        questMark = (GameObject)Instantiate(questMarkPrefab,gameObject.transform);
        questMark.transform.position = pos;
        questMark.SetActive(false);

        playerQuests = player.GetComponent<PlayerQuests>();

        questDescription = allQuests.GetQuestDescription(questToGive);
        replyDescription = allQuests.GetReply(questToGive);
        notFinishedReply = allQuests.GetNotFinishedReply(questToGive);
        finishedReply = allQuests.GetFinishedReply(questToGive);
        doIHaveAQuestToGive = questToGive != "";
        doIHaveAQuestToComplete = questToComplete != "";
    }
    void OnAwake() {
        questPanel.SetActive(false);
    }

    void LateUpdate() {
        string questToGiveStatus = "";
        string questToCompleteStatus = "";
        if (doIHaveAQuestToGive) {
            questToGiveStatus = playerQuests.GetQuestStatus(questToGive);
        }
        if (doIHaveAQuestToComplete) {
            questToCompleteStatus = playerQuests.GetQuestStatus(questToComplete);
        }
        bool isQuestReadyToPickUp = IsQuestReadyToPickUp();
        bool readyToTurnIn = IsQuestReadyToTurnIn();

        if (!isQuestReadyToPickUp && !readyToTurnIn && questToGiveStatus.Equals("Inactive") && questToCompleteStatus.Equals("Inactive")) {
            currentState = 1;
            questMark.SetActive(false);
        } else if (isQuestReadyToPickUp && questToGiveStatus.Equals("Inactive")) {
            currentState = 2;
            questMark.SetActive(true);
        } else if (questToGiveStatus.Equals("Active")) {
            currentState = 3;
            questMark.SetActive(false);
        } else if (questToCompleteStatus.Equals("Active") && !readyToTurnIn) {
            currentState = 4;
            questMark.SetActive(false);
        } else if (questToCompleteStatus.Equals("Active") && readyToTurnIn) {
            currentState = 5;
            questMark.SetActive(true);
        }

    }

    void OnMouseOver() {
        if (RightClickedOnMeWithinProperDistance()) {
            print(currentState);
            if (currentState == 2) {
                QuestIsReadyToGiveToPlayer();
            } else if (currentState == 3) {
                QuestIGaveIsNotCompletedYet();
            } else if (currentState == 4) {
                QuestRequirementsNotYetMetToTurnIn();
            } else if (currentState == 5) {
                QuestReadyToComplete();
            }
        }
    }

    /*5 Possible states for NPC to be in
     *  1. No quest to give to player. No quest to complete for player
     *  2. Quest ready to give to player. No quest to complete for player
     *  3. Quest already given to player, but player hasn't completed quest. No quest to complete for player
     *  4. No quest to give to player. NPC has quest to complete for player, but player hasn't filled requirements yet for quest
     *  5. No quest to give to player. Quest is ready to complete
     */

    private void QuestIsReadyToGiveToPlayer() { //State 2
        print("State 2");
        questTitleText.text = questToGive;
        questDescriptionText.text = questDescription;
        questPanel.SetActive(true);
        closeButton.SetActive(true);
        acceptButton.SetActive(true);
        completeButton.SetActive(false);
    }

    private void QuestIGaveIsNotCompletedYet() { //State 3
        print("State 3");
        questTitleText.text = questToGive;
        questDescriptionText.text = replyDescription;
        questPanel.SetActive(true);
        closeButton.SetActive(true);
        acceptButton.SetActive(false);
        completeButton.SetActive(false);
    }

    private void QuestRequirementsNotYetMetToTurnIn() { //State 4
        print("State 4");
        questTitleText.text = questToComplete;
        questDescriptionText.text = notFinishedReply;
        questPanel.SetActive(true);
        closeButton.SetActive(true);
        acceptButton.SetActive(false);
        completeButton.SetActive(false);
    }

    private void QuestReadyToComplete() { //State 5
        print("State 5");
        questTitleText.text = questToComplete;
        questDescriptionText.text = finishedReply;
        questPanel.SetActive(true);
        closeButton.SetActive(false);
        acceptButton.SetActive(false);
        completeButton.SetActive(true);
    }

    private bool RightClickedOnMeWithinProperDistance() {
        return Input.GetMouseButtonDown(1) && Vector3.Distance(this.transform.position, player.transform.position) < talkingRegisterDistance;
    }

    private bool IsQuestCompleted() {
        return playerQuests.IsQuestCompleted(questToGive);
    }

    private bool IsQuestReadyToTurnIn() {
        int numberNeeded = allQuests.GetNumberOfItemsNeeded(questToGive);
        string itemName = allQuests.GetItemNeeded(questToGive);
        //Check if player has numberNeeded of itemName in inventory
        //if true
            return true;
        //else
                //return false;
    }

    private bool IsQuestReadyToPickUp() {
        int requiredLevel = allQuests.GetLevelRequired(questToGive);
        string questRequired = allQuests.GetQuestRequired(questToGive);
        bool questInactive = playerQuests.GetQuestStatus(questToGive).Equals("Inactive");
        bool requiredQuestCompleted = true;
        if (questRequired != "") {
            requiredQuestCompleted = playerQuests.IsQuestCompleted(questRequired);
        }
        if (requiredQuestCompleted && questInactive) { //Check here if player level is high enough
            return true;
        }
        return false;
    }
}
