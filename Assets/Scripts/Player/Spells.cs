using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spells : MonoBehaviour {

    private List<List<spell>> spellList;

    struct spell
    {
        public string spellName;
        public float damage, cost, castTime;

        

    }
    
    void Start () {
        spell spells;
        List<spell> charSpells;
        spells.spellName = "";
        spells.damage = 5;
        spells.cost = 5;
        spells.castTime = 2;

        //charSpells.Add(spells);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
