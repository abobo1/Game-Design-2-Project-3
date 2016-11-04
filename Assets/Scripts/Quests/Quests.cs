using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests {
    
    private Hashtable allQuests = new Hashtable();

    public enum Status {ACTIVE, INACTIVE, COMPLETED};
    public Quests() {
        allQuests.Add("Quest1", new Quest("Quest1", "This is quest #1", "Go do quest 1", "You aren't ready to complete quest 1", "You finished quest 1", 150, new ArrayList(), Status.INACTIVE,
                                            0, "", 0, ""));
        allQuests.Add("Quest2", new Quest("Quest2", "This is quest #2", "Go do quest 2", "You aren't ready to complete quest 2", "You finished quest 2", 300, new ArrayList(), Status.INACTIVE,
                                            0, "", 0, "Quest1"));
        allQuests.Add("Quest3", new Quest("Quest3", "This is quest #3", "Go do quest 3", "You aren't ready to complete quest 3", "You finished quest 3", 300, new ArrayList(), Status.INACTIVE,
                                            0, "", 0, "Quest2"));
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

    public string GetReply(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.reply;
    }

    public string GetFinishedReply(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.finished;
    }

    public ArrayList GetItemsGiven(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.itemsGiven;
    }

    public int GetExp(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.experience;
    }

    public int GetNumberOfItemsNeeded(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.numberTurnInNeeded;
    }

    public string GetItemNeeded(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.itemToTurnIn;
    }

    public int GetLevelRequired(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.requiredLevel;
    }

    public string GetQuestRequired(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.requiredQuestCompleted;
    }

    public string GetNotFinishedReply(string questName) {
        Quest x = allQuests[questName] as Quest;
        return x.notFinished;
    }

    private class Quest {

        public string name;
        public string description;
        public string reply;
        public string notFinished;
        public string finished;
        public int experience;
        public ArrayList itemsGiven;
        public Status questStatus;
        public int numberTurnInNeeded;
        public string itemToTurnIn;
        public int requiredLevel;
        public string requiredQuestCompleted;

        public Quest(string name, string description, string reply, string notFinished, string finished, int experience, ArrayList itemsGiven, Status questStatus,
                        int numberTurnInNeeded, string itemToTurnIn, int requiredLevel, string requiredQuestCompleted) {
            this.name = name;
            this.description = description;
            this.reply = reply;
            this.notFinished = notFinished;
            this.finished = finished;
            this.experience = experience;
            this.itemsGiven = itemsGiven;
            this.questStatus = questStatus;
            this.numberTurnInNeeded = numberTurnInNeeded;
            this.itemToTurnIn = itemToTurnIn;
            this.requiredLevel = requiredLevel;
            this.requiredQuestCompleted = requiredQuestCompleted;
        }
    }

}
