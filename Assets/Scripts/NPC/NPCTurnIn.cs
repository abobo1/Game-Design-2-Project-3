using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class NPCTurnIn : MonoBehaviour
{

    private Quests allQuests = new Quests();

    public string questName,nextQuestName;
    private GameObject player;
    public GameObject NPCQuestGiver,nextNPCQuestGiver;
    public GameObject questMark;
    public GameObject replyPanel;
    public Text replyText;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        questName = NPCQuestGiver.GetComponent<NPCTalk>().questName;
        nextNPCQuestGiver.AddComponent<NPCTalk>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && player.GetComponent<PlayerQuests>().GetQuestStatus(questName) == "Active" && questName == NPCQuestGiver.GetComponent<NPCTalk>().questName && !nextNPCQuestGiver.GetComponent<NPCTalk>().questMark)
        {
            player.GetComponent<PlayerQuests>().CompleteQuest(questName);
            replyText.text = allQuests.GetReply(questName);
            ArrayList items = allQuests.GetItemsGiven(questName);//use to show what items we get
            replyText.text += "\n\nExperience Given: " + allQuests.GetExp(questName) ;
            questMark.SetActive(false);
            replyPanel.SetActive(true);
            NPCQuestGiver.GetComponent<NPCTalk>().enabled = false;
            //nextNPCQuestGiver.AddComponent<NPCTalk>().enabled = false;
            nextNPCQuestGiver.GetComponent<NPCTalk>().player = NPCQuestGiver.GetComponent<NPCTalk>().player;
            nextNPCQuestGiver.GetComponent<NPCTalk>().questMarkPrefab = NPCQuestGiver.GetComponent<NPCTalk>().questMarkPrefab;
            nextNPCQuestGiver.GetComponent<NPCTalk>().questName = nextQuestName;
            nextNPCQuestGiver.GetComponent<NPCTalk>().questPanel = NPCQuestGiver.GetComponent<NPCTalk>().questPanel;
            nextNPCQuestGiver.GetComponent<NPCTalk>().replyPanel = NPCQuestGiver.GetComponent<NPCTalk>().replyPanel;
            nextNPCQuestGiver.GetComponent<NPCTalk>().questTitleText = NPCQuestGiver.GetComponent<NPCTalk>().questTitleText;
            nextNPCQuestGiver.GetComponent<NPCTalk>().questDescriptionText = NPCQuestGiver.GetComponent<NPCTalk>().questDescriptionText;
            nextNPCQuestGiver.GetComponent<NPCTalk>().replyText = NPCQuestGiver.GetComponent<NPCTalk>().replyText;
            //nextNPCQuestGiver.GetComponent<NPCTalk>().enabled = true;
            //GetComponent<NPCTurnIn>().enabled = false;
            //nextNPCQuestGiver.GetComponent<NPCTalk>().questMark = NPCQuestGiver.GetComponent<NPCTalk>().questMark;


        }
    }
}
