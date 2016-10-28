using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerStat : MonoBehaviour {

    private float hpCurrent, hpMax, mpCurrent, mpMax, intellect, spirit, stamina, strength;
    private int playerLevel, skillPoints,skillPointMax;
    public int playerId;
    private List<Items> playerInv;
    private List<Spells> playerSpells;
    public GameObject playerHud;

    public playerStat()
    {
        
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
        playerHud = (GameObject)Instantiate(playerHud);
        playerHud.name = "spellBar";
        playerHud.GetComponent<playerHud>().playerId = playerId;
        //playerId = GameObject.Find("GameController").GetComponent<mainMenu>().playerId;
        //playerId = 0;//test only
        Spells playerSpells = new Spells(playerId);//test only set back to playerId
        //Items playerInv = new Items(true);
        playerInv playerINV = new playerInv();
        Items itemList = new Items(false);
        //Debug.Log(playerSpells.spellList[playerSpells.totalSpells-1].cost);
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
