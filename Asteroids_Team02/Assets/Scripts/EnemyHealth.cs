using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 3;
    public int currentHealth;

    AudioSource enemyAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        // Set current health when enemy spawns
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        
        Destroy(gameObject, 0.05f);
    }
}
