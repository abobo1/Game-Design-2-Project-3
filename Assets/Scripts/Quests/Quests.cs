using System;
using System.Collections;
using System.Collections.Generic;

public class Quests {
    
    private Hashtable allQuests = new Hashtable();

    public enum Status {ACTIVE, INACTIVE, COMPLETED};
    public Quests() {
        allQuests.Add("Quest1", new Quest("Quest1", "This is quest #1","You finished quest 1", 150, new ArrayList(), 1,Status.INACTIVE));
        allQuests.Add("Quest2", new Quest("Quest1", "This is quest #2","You finished quest 2", 300, new ArrayList(), 1,Status.INACTIVE));
    }

    public string GetQuestName(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.name;
    }

    public string GetQuestDescription(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.description;
    }

    public int GetQuestExperience(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.experience;
    }

    public bool IsQuestCompleted(string questName) {
        Quest x = allQuests[questName] as Quest;
        if (x.questStatus == Status.COMPLETED) {
            return true;
            } else {
                return false;
            }
    }

    public void CompleteQuest(string questName) {
        Quest x = allQuests[questName] as Quest;
        x.questStatus = Status.COMPLETED;
        allQuests[questName] = x;
    }

    public void SetQuestStatus(string name,Status questStatus)
    {
        Quest quest = allQuests[name] as Quest;
        quest.questStatus = questStatus;
        allQuests[name] = quest;
    }

    public void SetQuestStatus(string questName, string status) {
        Quest quest = allQuests[questName] as Quest;
        switch (status) {
            case "INACTIVE":
            case "Inactive":
            case "inactive":
                quest.questStatus = Status.INACTIVE;
                break;
            case "ACTIVE":
            case "Active":
            case "active":
                quest.questStatus = Status.ACTIVE;
                break;
            case "COMPLETED":
            case "Completed":
            case "completed":
                quest.questStatus = Status.COMPLETED;
                break;
        }
        allQuests[questName] = quest;
    }

    public string GetQuestStatus(string questName) {
        Quest quest = allQuests[questName] as Quest;
        switch (quest.questStatus) {
            case Status.ACTIVE:
                return "Active";
            case Status.INACTIVE:
                return "Inactive";
            case Status.COMPLETED:
                return "Completed";
            default:
                return "Error";
        }
    }

    public string getReply(string questName)
    {
        Quest x = allQuests[questName] as Quest;
        return x.reply;
    }

    private class Quest {

        public string name;
        public string description,reply;
        public int experience;
        public ArrayList itemsGiven;
        public int levelRequired;
        public Status questStatus;

        public Quest(string name, string description,string reply, int experience, ArrayList itemsGiven, int levelRequired,Status questStatus) {
            this.name = name;
            this.description = description;
            this.reply = reply;
            this.experience = experience;
            this.itemsGiven = itemsGiven;
            this.levelRequired = levelRequired;
            this.questStatus = questStatus;
        }
    }

}
