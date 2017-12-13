using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrossHealth : MonoBehaviour {

    public int startingHealth = 1000;
  //  public ParticleSystem magiccalExplosionParticle;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;

    bool isDead = false;
    bool damaged;

	// Use this for initialization
	void Awake () {
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
      
        
	}

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
           
        }
    }

    void Death()
    {
        isDead = true;
        // Destroy(gameObject);
        gameObject.SetActive(false);
     //   magiccalExplosionParticle.transform.parent = null;
      //  magiccalExplosionParticle.Play();
        
    }
}
