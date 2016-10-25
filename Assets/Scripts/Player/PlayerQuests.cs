using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerQuests : MonoBehaviour {

    private Quests playerQuests = new Quests();
    private long count = 0;
    public Text questTitle;

    //Just here to quickly complete the quest. For testing
    void Start()
    {
        GameObject.Find("QuestPanel").SetActive(false);
        GameObject.Find("ReplyPanel").SetActive(false);

    }

   
    void Update() {
        //count++;
        //if (count > 300) {
        //    CompleteQuest("Quest1");
        //}
    }


    public void SetQuestStatus(string name, string status) {
        playerQuests.SetQuestStatus(name, status);
    }

    public string GetQuestStatus(string name) {
        return playerQuests.GetQuestStatus(name);
    }

    public bool IsQuestCompleted(string questName) {
        return playerQuests.IsQuestCompleted(questName);
    }

    public void CompleteQuest(string questName) {
        playerQuests.CompleteQuest(questName);
        //Take items from this quest out of inventory
        //Get reward for this quest (XP and Items)
    }
}
