using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;
    private bool isInvulnerable;

    private CollisionManager collisionManager;

    void Start()
    {
        currentHealth = maxHealth;
        collisionManager = GetComponent<CollisionManager>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable || currentHealth <= 0) return;

        currentHealth -= damage;
        Debug.Log("Vida: " + currentHealth);

        if (currentHealth <= 0)
        {
            collisionManager.Die();
        }
        else
        {
            isInvulnerable = true;
            Invoke(nameof(EndInvulnerability), 1f);
        }
    }

    private void EndInvulnerability()
    {
        isInvulnerable = false;
    }

    public void RecoverHealth(int amount)
    {
        if (currentHealth <= 0) return;

        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }
}
