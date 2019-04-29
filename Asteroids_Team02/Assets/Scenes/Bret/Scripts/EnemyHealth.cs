using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 3;
    public int currentHealth;
    public ParticleSystem explodeAnimation;

    AudioSource enemyAudio;

    // Start is called before the first frame update
    void Start()
    {
        explodeAnimation.Stop();
    }

    private void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();

        // Set current health when enemy spawns
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    public void TakeDamage()
    {
        enemyAudio.Play();
        currentHealth--;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        print(explodeAnimation.isPlaying);

        if (!explodeAnimation.isPlaying)
        {
            explodeAnimation.Play();
            Destroy(gameObject, 0.8f);
            GameInfo.UpdateScore();
        }

    }
}
