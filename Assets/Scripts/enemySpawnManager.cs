using UnityEngine;
using System.Collections;

public class enemySpawnManager : MonoBehaviour {

    public GameObject[] enemy;
    public int distance;
    public float spawnTime; 
    public Transform[] spawnPoints;
    public Transform player;
    private bool spawned = false;

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
            if(!spawned)
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    int enemyIndex = Random.Range(0, enemy.Length);
                    Instantiate(enemy[enemyIndex], spawnPoints[i].position, spawnPoints[i].rotation);
                }
                spawned = true;
            }
        }
    }
}
