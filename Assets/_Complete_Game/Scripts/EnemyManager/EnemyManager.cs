using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public CrossHealth crossHealth;
    public GameObject enemy;
    public float SpawnTime = 3f;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
	}
	
	// Update is called once per frame
	void Spawn() {
		if(crossHealth.currentHealth <= 0)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
