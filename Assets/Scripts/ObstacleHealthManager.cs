using UnityEngine;

public class ObstacleHealthManager : MonoBehaviour
{
    [SerializeField] private int currentHealth = 3;
    [SerializeField] private ParticleSystem explosionParticlesSystem;

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            ParticleSystem explosion = Instantiate(explosionParticlesSystem);
            explosion.transform.position = transform.position;
            explosion.Play();

            Destroy(gameObject);
        }
    }
}
