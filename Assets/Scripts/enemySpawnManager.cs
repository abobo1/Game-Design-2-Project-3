using UnityEngine;
using System.Collections;

public class enemySpawnManager : MonoBehaviour {

    public GameObject enemy;
    public int spawnAmount;
    public int distance;
    public float spawnTime; 
    public Transform[] spawnPoints;
    public Transform player;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (Vector3.Distance(transform.position, player.position) < distance)
        {
            GameObject[] array;
            array = GameObject.FindGameObjectsWithTag("Enemy");
            if (spawnAmount > array.Length)
            {
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
        }
    }
}
