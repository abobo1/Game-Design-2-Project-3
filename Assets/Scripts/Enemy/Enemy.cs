using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Transform target;
    private float speed = 2.5f;
    private float attack1Range = 10f;
    private float attack2Range = 5f;
    private float attackRange;
    private int attack1Damage = 1;
    private int attack2Damage = 1;
    private float timeBetweenAttacks;
    public Animator ani;
    public HashID hash;
    private float attackDistance;
    private GameObject player;
    public string enemyType;


	

	// Use this for initialization
	void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        ani = GetComponent<Animator>();
        hash = GetComponent<HashID>();
       // ani.SetFloat(hash.speed, 5f);
        Rest ();

        if (enemyType == "Close")
            attackRange = attack2Range;
        else if (enemyType == "Ranged")
            attackRange = attack1Range;

	}
	
	// Update is called once per frame
	void Update () {
        //ani.SetFloat(hash.speed, 5f);
        GetComponent<Animator>().SetFloat(GetComponent<HashID>().speed, 0);
        attackDistance = Vector3.Distance(transform.position, target.position);
		if(attackDistance < 50.0f) {
			MoveToPlayer();
        }
		else {
			//Rest();
		}
	}

	public void MoveToPlayer ()
    {
        //rotate to look at player
        transform.LookAt (target);
        //transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
		//enemyAni.SetFloat(enemyHashID.speed, 3.0f);
         
        //move towards player
        if (Vector3.Distance (transform.position, target.position) > attackRange) 
        {
            //transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
            //enemyAni.SetFloat(enemyHashID.speed, 5);
        }
    }
 
    public void Rest ()
    {
        //ani.SetFloat(hash.speed, 0);
        GetComponent<Animator>().SetFloat(GetComponent<HashID>().speed, 0);
    }
}
