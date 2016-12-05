using UnityEngine;
using System.Collections;

public class playerInteract : MonoBehaviour
{
    public GameObject spellBall, spellSpawn;

    public void useAbility(int id)
    {
        //check for resources
        //if (GetComponent<playerStat>().playerSpells[id].getCost(id) < GetComponent<playerStat>().getMpCurrent())
        if (GetComponent<playerStat>().checkAbility(id))
        {
            GetComponent<PlayerAnimation>().attackType = id;
            GetComponent<PlayerAnimation>().usingAbility = true;
            GetComponent<playerStat>().setMpCurrent(-GetComponent<playerStat>().playerSpells.getCost(id));

            GameObject spell = (GameObject)Instantiate(spellBall,spellSpawn.transform.position,spellSpawn.transform.rotation);
            
        }
    }
}