using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class NPCTalk : MonoBehaviour {

    public string questName;
    private string questDescription,replyDescription;

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
        
        //player = GameObject.FindGameObjectWithTag("Player");
        //questMark = GameObject.Find("QuestMark");
        //questPanel = GameObject.Find("QuestPanel");
        //replyPanel = GameObject.Find("ReplyPanel");

        questDescription = allQuests.GetQuestDescription(questName);
        replyDescription = allQuests.getReply(questName);
    }
    void OnAwake()
    {
        //questMark = (GameObject)Instantiate(questMarkPrefab, transform);
        //moved from start to awake due to other instances not being able to see this object when setActive(false)
        questPanel.SetActive(false);
        replyPanel.SetActive(false);
    }

    void Update() {
        //proof of concept
        //if (IsQuestCompleted()) {
        //questMark.SetActive(false);
        //}
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(1) && questMark) {
            print("Right click on this object");
            if (Vector3.Distance(this.transform.position, player.transform.position) < talkingRegisterDistance) {
                print("You are close enough");

                //test

                //Debug.Log(player.GetComponent<PlayerQuests>().GetQuestStatus(questName));
                //end test
                if (!IsQuestCompleted()) {
                    if (player.GetComponent<PlayerQuests>().GetQuestStatus(questName) != "Active")
                    {
                        print("Quest is not completed yet");
                        questTitleText.text = questName;
                        questDescriptionText.text = questDescription;
                        replyText.text = questDescription;
                        //replyText.text = player.GetComponent<PlayerQuests>().GetReply(questName);
                        questPanel.SetActive(true);
                        questMark.SetActive(false);

                    }
                    else
                    {
                        questPanel.SetActive(false);
                        replyPanel.SetActive(true);
                    }
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
