using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 20;
    public int currentHealth;
    public float sinkSpeed = 1.0f;
    public int scoreValue = 10;
    public AudioSource deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticle;
    CapsuleCollider capsuleColider;
    bool isDead;
    bool isSinking;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        capsuleColider = GetComponent<CapsuleCollider>();
        hitParticle = GetComponentInChildren<ParticleSystem>();
        currentHealth = startingHealth;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            isSinking = true;
            StartSinking();
        }
    }


    void Death()
    {
        isDead = true;

    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        deathClip.Play();
        ScoreManager.score += scoreValue; 
        Destroy(gameObject, 2f);

    }
}
