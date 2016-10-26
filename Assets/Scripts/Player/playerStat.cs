using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerStat : MonoBehaviour {

    private float hpCurrent, hpMax, mpCurrent, mpMax, intellect, spirit, stamina, strength;
    private int playerId, playerLevel, skillPoints,skillPointMax;
    private List<Items> playerInv;
    private List<Spells> playerSpells;

    public playerStat()
    {
        playerId = GameObject.Find("GameController").GetComponent<mainMenu>().playerId;
        playerLevel = 1;
        skillPoints = 0;
        skillPointMax = 0;
        spirit = 20;
        stamina = 20;

        if (playerId == 0 || playerId == 2)
        { intellect = 20; strength = 5;}
        else
        { intellect = 5;strength = 20; }

    }

    void Start() {

    }
    public float getHpCurrent(){
        return hpCurrent;
    }
    public float getHpMax(){
        return hpMax;
    }
    public float getMpCurrent()
    {
        return mpCurrent;
    }
    public float getMpMax()
    {
        return mpMax;
    }

    public int getLevel()
    {
        return playerLevel;
    }
    public int getSkillPoints()
    {
        return skillPoints;
    }
    
    void setHealthandMp()
    {
        hpCurrent = getHpMax();
        mpCurrent = getMpMax();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
