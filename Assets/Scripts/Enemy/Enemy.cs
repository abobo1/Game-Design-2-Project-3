using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Transform target;
    public float speed = 2.5f;
    public float attack1Range = 1f;
    public int attack1Damage = 1;
    public float timeBetweenAttacks;
	private Animator enemyAni;
	private HashID enemyHashID;
	public float attackDistance;

	

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
		enemyAni = GetComponent<Animator>();
		enemyHashID = GetComponent<HashID>();
		Rest ();
	}
	
	// Update is called once per frame
	void Update () {
		attackDistance = Vector3.Distance(transform.position, target.position);
		if(attackDistance < 50.0f) {
			MoveToPlayer();
		}
		else {
			Rest();
		}
	}

	public void MoveToPlayer ()
    {
        //rotate to look at player
        transform.LookAt (target.position);
        transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
		enemyAni.SetFloat(enemyHashID.speed, 3.0f);
         
        //move towards player
        if (Vector3.Distance (transform.position, target.position) > attack1Range) 
        {
            transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
        }
    }
 
    public void Rest ()
    {
		enemyAni.SetFloat(enemyHashID.speed, 0.0f);
    }
}
