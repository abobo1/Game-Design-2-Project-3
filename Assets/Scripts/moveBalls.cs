using UnityEngine;
using System.Collections;

public class moveBalls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, 2.5f);
        Destroy(gameObject, 0.5f);

    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Enemy")
            Destroy(col.gameObject);
    }
}
