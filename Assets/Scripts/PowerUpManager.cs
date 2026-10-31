using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private PowerUpScriptableObject powerUpData;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (powerUpData.PowerUpType == "Health")
            {
                other.GetComponent<PlayerHealthManager>()
                    .RecoverHealth(powerUpData.PowerUpValue);
            }
            else if (powerUpData.PowerUpType == "Ammo")
            {
                other.GetComponent<PlayerShooting>()
                    .RecoverAmmo(powerUpData.PowerUpValue);
            }

            Destroy(gameObject);
        }
    }
}
