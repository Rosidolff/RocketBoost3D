using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Ammo Settings")]
    [SerializeField] private int currentAmmo = 10;
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private bool infiniteAmmo = false;

    [Header("Shooting Settings")]
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float bulletRate = 0.25f;
    [SerializeField] private int BulletDamage = 1;

    // [Header("Shooting point")]
    [SerializeField] private Transform bulletSpawnPoint;

    private ObjectPool bulletPool;

    private float lastShotTime = 0f;

    void Start()
    {
        bulletSpawnPoint = transform.Find("ShootPoint");
        bulletPool = GetComponent<ObjectPool>();
    }

    public void RecoverAmmo(int amount)
    {
        currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
        Debug.Log("Munición: " + currentAmmo);
    }

    public bool CanShoot()
    {
        // Check if enough time has passed since the last shot and if there is ammo available (or if infinite ammo is enabled)
        if ((Time.time - lastShotTime >= bulletRate) && (currentAmmo > 0 || infiniteAmmo))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Shoot a bullet from the ojet pool and apply.
    /// </summary>
    public void Shoot()
    {
        if (CanShoot())
        {
            // Update last shot time.
            lastShotTime = Time.time;
            //reduce the ammo.
            if (!infiniteAmmo) currentAmmo--;
            ///Get a bullet from the object pool.
            GameObject bullet = bulletPool.GetObjectFromPool();
            bullet.GetComponent<BulletController>().SetDamage(BulletDamage);
            // Set the bullet's position and rotation to the spawn point.
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = bulletSpawnPoint.rotation;

            // Set the bullet's velocity to move it forward.
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.linearVelocity = bulletSpawnPoint.up * bulletSpeed;

        }

        
    }



}
