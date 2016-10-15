using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float moveSpeed, turningspeed;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");
        
        if (vert >0)
            transform.Translate(0, 0, vert * moveSpeed * Time.deltaTime);
        else if (vert < 0)
            transform.Translate(0, 0, vert * moveSpeed/3 * Time.deltaTime);
        transform.Rotate(0, horiz * Time.deltaTime * turningspeed , 0);
	
	}
}
