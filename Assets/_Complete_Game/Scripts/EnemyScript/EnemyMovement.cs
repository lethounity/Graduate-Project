using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Transform cross;
    UnityEngine.AI.NavMeshAgent nav;
    CrossHealth crossHealth;
    EnemyHealth enemyHealth;

    private void Awake()
    {
        cross = GameObject.FindGameObjectWithTag("Cross").transform;
        crossHealth = cross.GetComponent<CrossHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth.currentHealth > 0 && crossHealth.currentHealth > 0)
        {
            nav.SetDestination(cross.position);
        }
        else
        {
            nav.enabled = false;
        }
	}
}
