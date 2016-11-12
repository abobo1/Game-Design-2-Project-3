using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spells : MonoBehaviour
{

    public List<spell> spellList;
    public ArrayList spells;
    public int playerId = -1;
    public int  numSpells = 0, totalSpells = 6;


   
    public float getCost (int id)
    {
        return spellList[id].cost;
    }
    public float getDamage (int id)
    {
        return spellList[id].damage;
    }
    public struct spell
    {
        public string spellName;
        public float damage, cost, castTime;
    }

    public Spells(int playerId)
    {
        spells = new ArrayList();
        spell newSpell = new spell();
        spellList = new List<spell>();
        while (spells.Count < totalSpells)
        {
            setSpell(newSpell, playerId);
            spells.Add(spellList);
            
        }
    }
    void setSpell(spell newSpell, int playerId)//add all character spells here
    {
        if (playerId == 0)
        {
            //add each unique spell here
            spellList.Add(addSpell(newSpell, "name", 5, 4, 3));
            spellList.Add(addSpell(newSpell, "name", 5, 10, 3));
            spellList.Add(addSpell(newSpell, "name", 5, 4, 3));
            spellList.Add(addSpell(newSpell, "name", 5, 4, 3));
            spellList.Add(addSpell(newSpell, "name", 5, 4, 3));
            spellList.Add(addSpell(newSpell, "name", 5, 4, 3));
        }

    }
    
    spell addSpell(spell newSpell, string spellName, float spellDamage, float spellCost, float spellCastTime)
    {
        //newSpell = new spell();

        newSpell.spellName = spellName;
        newSpell.damage = spellDamage;
        newSpell.cost = spellCost;
        newSpell.castTime = spellCastTime;

        return newSpell;
    }
    
}