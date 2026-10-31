using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float BulletlifeTime = 1f;
    [SerializeField] private ParticleSystem impactParticlesSystem;

    private int damage;
    private bool hasHit;

    void OnEnable()
    {
        hasHit = false;
        CancelInvoke(nameof(DeactivateBullet));
        Invoke(nameof(DeactivateBullet), BulletlifeTime);
    }

    public void SetDamage(int bulletDamage)
    {
        damage = bulletDamage;
    }

    private void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;
        if (other.CompareTag("Player")) return;
        if (other.CompareTag("PowerUp")) return;

        hasHit = true;

        ObstacleHealthManager obstacleHealth = other.GetComponent<ObstacleHealthManager>();

        if (obstacleHealth != null)
        {
            obstacleHealth.TakeDamage(damage);
        }

        ParticleSystem impact = Instantiate(impactParticlesSystem);
        impact.transform.position = transform.position;
        impact.Play();

        DeactivateBullet();

    }
    
}
