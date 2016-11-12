using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    private Animator ani;
    private HashID hash;
    public int attackType;
    public bool usingAbility;
	void Start () {
        ani = GetComponent<Animator>();
        hash = GetComponent<HashID>();
	
	}
	
	// Update is called once per frame
	void Update () {
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");

        if (!vert.Equals(0))
        {
            ani.SetFloat(hash.speed, 5f * vert);
        }
        else ani.SetFloat(hash.speed, 0);

        //attack and heals
        if (usingAbility)
        {
            if (attackType == 0)
            ani.SetBool(hash.attack1, true);
            else if (attackType == 1)
                ani.SetBool(hash.attack2, true);

            usingAbility = false;

        }
        else
        {
            ani.SetBool(hash.attack1, false);
            ani.SetBool(hash.attack2, false);
        }



    }
}
