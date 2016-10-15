using UnityEngine;
using System.Collections;

public class HashID : MonoBehaviour {

    public int speed, isJumping;

	void Start () {
        speed = Animator.StringToHash("speed");
        isJumping = Animator.StringToHash("isJumping");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
