using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    private Animator ani;
    private HashID hash;
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



    }
}
