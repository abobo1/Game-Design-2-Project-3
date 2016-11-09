using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float moveSpeed, turningspeed;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");
        /*
        if (vert > 0)
            transform.Translate(0, 0, vert * moveSpeed * Time.deltaTime);
        else if (vert < 0)
            transform.Translate(0, 0, vert * moveSpeed/3 * Time.deltaTime);
            */
        CharacterController controller = GetComponent<CharacterController>();

        if(vert > 0)
        {
            moveDirection = new Vector3(horiz, 0, vert);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            transform.Rotate(Vector3.up, 2 * horiz * Time.deltaTime * turningspeed);
        }
        else if(vert < 0)
        {
            moveDirection = new Vector3(horiz, 0, vert);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed/3;
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            transform.Rotate(Vector3.up, 2 * horiz * Time.deltaTime * turningspeed);
        }
        else
            transform.Rotate(Vector3.up, horiz * Time.deltaTime * turningspeed);

	}
}
