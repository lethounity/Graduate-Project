using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruin : MonoBehaviour {

    
    public CrossHealth crossHealth;
    public GameObject ruin;
    public Transform position;

    float timer=0f;
    int num;
    
    //bool isActive = false;
	// Use this for initialization


	void Awake () {
        //  Invoke("SetAlive", 0);
        num = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(crossHealth.currentHealth > -10 && crossHealth.currentHealth < 1 && timer >3)
        Invoke("SetAlive", 0);
	}

    void SetAlive()
    {
        timer = 0f;
        if(num<1)
        Instantiate(ruin, position);
        num += 2;
    }
}
