using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Collider works but not really");
        Debug.Log(collider.gameObject.name);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
