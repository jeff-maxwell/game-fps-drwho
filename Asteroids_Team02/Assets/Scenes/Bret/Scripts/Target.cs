using UnityEngine;

public class Target : MonoBehaviour
{
    public float startingHealth = 50f;
    public float currentHealth;
    public ParticleSystem explodeAnimation;

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
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //print(explodeAnimation.isPlaying);

        if (!explodeAnimation.isPlaying)
        {
            explodeAnimation.Play();
            Destroy(gameObject, 0.8f);
        }
    }
}
