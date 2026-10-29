using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float BulletlifeTime = 1f;

    void OnEnable()
    {
        Invoke(nameof(DeactivateBullet), BulletlifeTime);
    }

    private void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        DeactivateBullet();
         //TODO particles
        // TODO if Bullet hits enemy, reduce enemy health
        // TODO if Bullet hits obstacle, destroy obstacle
        // TODO if Bullet hits player, reduce player health

    }
    
}
