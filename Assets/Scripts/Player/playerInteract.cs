using UnityEngine;
using System.Collections;

public class playerInteract : MonoBehaviour
{
    public void useAbility(int id)
    {
        //check for resources
        //if (GetComponent<playerStat>().playerSpells[id].getCost(id) < GetComponent<playerStat>().getMpCurrent())
        if (GetComponent<playerStat>().checkAbility(id))
        {
            GetComponent<PlayerAnimation>().attackType = id;
            GetComponent<PlayerAnimation>().usingAbility = true;
            GetComponent<playerStat>().setMpCurrent(-GetComponent<playerStat>().playerSpells.getCost(id));
        }
    }
}