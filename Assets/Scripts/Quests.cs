using System;
using System.Collections;
using System.Collections.Generic;

public class Quests {

    private List<Quest> allQuests = new List<Quest>(new Quest[] {
        new Quest("Test1", "This is quest #1", 150, false),
        new Quest("Test2", "This is quest #2", 300, false)
    });

    public String GetQuestName(int questNumber) {
        return allQuests[questNumber].name;
    }

    public String GetQuestDescription(int questNumber) {
        return allQuests[questNumber].description;
    }

    public int GetQuestExperience(int questNumber) {
        return allQuests[questNumber].experience;
    }

    public bool IsQuestCompleted(int questNumber) {
        return allQuests[questNumber].completed;
    }

    public void CompleteQuest(int questNumber) {
        allQuests[questNumber].completed = true;
    }







    private class Quest {

        public String name;
        public String description;
        public int experience;
        public bool completed;
        public ArrayList test;

        public Quest(String name, String description, int experience, bool completed) {
            this.name = name;
            this.description = description;
            this.experience = experience;
            this.completed = completed;
        }
    }

}
