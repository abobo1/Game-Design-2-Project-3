using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerStat : MonoBehaviour {

    public float hpCurrent, hpMax, mpCurrent, mpMax, intellect, spirit, stamina, strength;
    private int playerLevel, skillPoints,skillPointMax;
    public int playerId;
    private List<Items> playerInv;
    //public List<Spells> playerSpells;
    public Spells playerSpells;// = new Spells(playerId);//test only set back to playerId
    public GameObject playerHud;
    public float healthScale, manaScale;
    


   

    void Start() {
        playerLevel = 1;
        skillPoints = 0;
        skillPointMax = 0;
        spirit = 20;
        stamina = 20;
        

        if (playerId == 0 || playerId == 2)
        { intellect = 20; strength = 5; }
        else
        { intellect = 5; strength = 20; }

        hpMax = stamina * 2.5f;
        mpMax = intellect * 2.5f;
        resetHealtManaToMax();


        playerHud = (GameObject)Instantiate(playerHud);

        healthScale = GameObject.Find("healthImage").gameObject.transform.localScale.x;
        //GameObject.Find("healthImage").gameObject.transform.localScale.x = GameObject.Find("healthImage").gameObject.transform.localScale.x / 2;
        playerHud.name = "spellBar";
        playerHud.GetComponent<playerHud>().playerId = playerId;
        //playerId = GameObject.Find("GameController").GetComponent<mainMenu>().playerId;
        //playerId = 0;//test only
        //Spells playerSpells = new Spells(playerId);//test only set back to playerId
        playerSpells = new Spells(playerId);//test only set back to playerId
        //Items playerInv = new Items(true);
        playerInv playerINV = new playerInv();
        Items itemList = new Items(false);
        //Debug.Log(playerSpells.getCost(0));
    }
    public bool checkAbility (int id)
    {
        if (playerSpells.getCost(id) <= getMpCurrent())
            return true;
        else
            return false;
    }
    public void setHpCurrent (float amount)
    {
        hpCurrent += amount;
        if (hpCurrent > hpMax)
            hpCurrent = getHpMax();
        else
        {
            //die
        }

    }
    public void setMpCurrent (float amount)
    {
        mpCurrent += amount;
        if (mpCurrent > mpMax)
            mpCurrent = mpMax;
        else
        {
            //oh well...
        }
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
    
    void resetHealtManaToMax()
    {
        hpCurrent = getHpMax();
        mpCurrent = getMpMax();
    }
	
    public void AddMana(int amount) {
        mpCurrent = mpCurrent + amount;
        if (mpCurrent > mpMax) {
            mpCurrent = mpMax;
        }
    }

    public void RemoveMana(int amount) {
        mpCurrent = mpCurrent - amount;
        if (mpCurrent < 0) {
            mpCurrent = 0;
        }
    }

    public void AddHealth(int amount) {
        hpCurrent = hpCurrent + amount;
        if (hpCurrent > hpMax) {
            hpCurrent = hpMax;
        }
    }

    public void RemoveHealth(int amount) {
        hpCurrent = hpCurrent - amount;
        if (hpCurrent <= 0) {
            //DEAD
        }
    }
}
