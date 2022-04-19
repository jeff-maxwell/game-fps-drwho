﻿using UnityEngine;

public class Target : MonoBehaviour
{
    public float startingHealth = 50f;
    public float currentHealth;
    public ParticleSystem explodeAnimation;

    private bool isAlive = true;
    AudioSource enemyAudio;

    // Start is called before the first frame update
    void Start()
    {
        explodeAnimation.Stop();
        currentHealth = startingHealth;
    }

    private void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
    }

    public void TakeDamage(float amount)
    {
        if (isAlive)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                isAlive = false;
                Die();
            }
        }
    }

    void Die()
    {
        //print(explodeAnimation.isPlaying);
        GameInfo.UpdateScore();
        if (!explodeAnimation.isPlaying)
        {
            explodeAnimation.Play();
            Destroy(gameObject, 0.8f);
        }
    }
}
