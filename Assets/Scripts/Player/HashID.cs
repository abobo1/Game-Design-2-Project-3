using UnityEngine;
using System.Collections;

public class HashID : MonoBehaviour {

    public int speed, isJumping,attack1,attack2,heal1,heal2;

	void Start () {
        speed = Animator.StringToHash("speed");
        isJumping = Animator.StringToHash("isJumping");
        attack1 = Animator.StringToHash("attack1");
        attack2 = Animator.StringToHash("attack2");
        heal1 = Animator.StringToHash("heal1");
        heal2 = Animator.StringToHash("heal2");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
