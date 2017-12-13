using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    public CrossHealth crossHealth;
    public float restartDelay = 14f;

    Animator anim;
    float restartTimer;
    float timer;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        ResetTimer();

		if(crossHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}

    private void ResetTimer()
    {
       if(timer > 8)
        {
            restartTimer = 0;
            timer = 0;
        }
    }

}
