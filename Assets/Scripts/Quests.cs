using System;
using System.Collections;
using System.Collections.Generic;

public class Quests {

    private Hashtable allQuests = new Hashtable();

    public Quests() {
        allQuests.Add("Quest1", new Quest("Quest1", "This is quest #1", 150, false, new ArrayList(), 1));
        allQuests.Add("Quest2", new Quest("Quest1", "This is quest #2", 300, false, new ArrayList(), 1));
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
        return x.completed;
    }

    public void CompleteQuest(string questName) {
        Quest x = allQuests[questName] as Quest;
        x.completed = true;
        allQuests[questName] = x;
    }

    private class Quest {

        public string name;
        public string description;
        public int experience;
        public bool completed;
        public ArrayList itemsGiven;
        public int levelRequired;

        public Quest(string name, string description, int experience, bool completed, ArrayList itemsGiven, int levelRequired) {
            this.name = name;
            this.description = description;
            this.experience = experience;
            this.completed = completed;
            this.itemsGiven = itemsGiven;
            this.levelRequired = levelRequired;
        }
    }

}
