using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack_1 : MonoBehaviour {

    public float timeBeetweenAttacks = 1.5f;
    public int attackDamage =10;

    public AudioSource attackSound;
  

    Animator anim;
    GameObject cross;
    CrossHealth crossHealth;
    EnemyHealth enemyHealth;
    bool crossInRange = false;
    float timer;
    bool isAttack;
    bool crossEnabale = true;
   


    private void Awake()
    {
        cross = GameObject.FindGameObjectWithTag("Cross");
        crossHealth = cross.GetComponent<CrossHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == cross)
        {
            crossInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == cross)
        {
            crossInRange = false;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(crossInRange && timer >= timeBeetweenAttacks && crossHealth.currentHealth >0)
        {
            Attack();
        }

        anim.SetBool("NotAttack", !isAttack);
        
   
	}

    void Attack()
    {
        timer = 0f;
        isAttack = true;
        anim.SetBool("IsAttack", isAttack);
        attackSound.Play();

        if (crossHealth.currentHealth > 0)
        {
            crossHealth.TakeDamage(attackDamage);
            
        }
    }
}
