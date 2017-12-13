using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public int damagePerHit = 10;
    public float timeBetweenHit = 2f;
    public float attackRangeRadius = 2;
    public float attackForce = 100;
    

    float timer;
    int hitMask;
    AudioSource hitAudio;
    Animator anim;
    bool isAttack;
	// Use this for initialization
	void Awake () {
        hitAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        hitMask = LayerMask.GetMask("hitMask");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;

        isAttack = Input.GetButton("Attack");
        if (isAttack && timer >= timeBetweenHit)
        {
            Attack(isAttack);
            
        }
	}


    // Find enemies in Attack Radius and Damage them
    private void OnTriggerEnter(Collider other)
    {
 
    }

    

    void Attack(bool Attack)
    {
        timer = 0f;
        hitAudio.Play(12000);
        anim.SetBool("IsAttack", Attack);

        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRangeRadius, hitMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            // if (!targetRigidbody)
            //   continue;
            targetRigidbody.AddExplosionForce(attackForce, transform.position, attackRangeRadius);
            EnemyHealth targetHealth = targetRigidbody.GetComponent<EnemyHealth>();

            // if (!targetHealth)
            //   continue;

            targetHealth.TakeDamage(damagePerHit);

        }

    }
}
