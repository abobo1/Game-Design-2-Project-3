using System;
using System.Collections;
using System.Collections.Generic;

public class Quests {

    private Hashtable allQuests = new Hashtable();

    public Quests() {
        allQuests.Add("Quest1", new Quest("Test1", "This is quest #1", 150, false));
        allQuests.Add("Quest2", new Quest("Test2", "This is quest #2", 300, false));
    }

    public String GetQuestName(String questName) {
        Quest x = allQuests[questName] as Quest;
        return x.name;
    }

    public String GetQuestDescription(String questName) {
        Quest x = allQuests[questName] as Quest;
        return x.description;
    }

    public int GetQuestExperience(String questName) {
        Quest x = allQuests[questName] as Quest;
        return x.experience;
    }

    public bool IsQuestCompleted(String questName) {
        Quest x = allQuests[questName] as Quest;
        return x.completed;
    }

    public void CompleteQuest(String questName) {
        Quest x = allQuests[questName] as Quest;
        x.completed = true;
        allQuests[questName] = x;
    }

    private class Quest {

        public String name;
        public String description;
        public int experience;
        public bool completed;
       // public ArrayList itemsGiven;

        public Quest(String name, String description, int experience, bool completed) {
            this.name = name;
            this.description = description;
            this.experience = experience;
            this.completed = completed;
        }
    }

}
