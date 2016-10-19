using UnityEngine;
using System.Collections;

public class PlayerQuests : MonoBehaviour {

    private Quests playerQuests = new Quests();

    public bool IsQuestCompleted(string questName) {
        return playerQuests.IsQuestCompleted(questName);
    }

    public void CompleteQuest(string questName) {
        playerQuests.CompleteQuest(questName);
    }
}
