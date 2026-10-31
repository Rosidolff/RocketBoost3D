using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip explosionAudioClip;
    [SerializeField] private AudioClip landingAudioClip;

    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem explosionParticlesSystem;
    [SerializeField] private ParticleSystem landingParticlesSystem;

    AudioSource audioSource;
    private PlayerHealthManager playerHealth;

    bool isControllable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealthManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isControllable) return;

        switch (collision.gameObject.tag)
        {
            case "LaunchPad":
                Debug.Log("Landed on launchpad");
                break;
            case "LandingPad":
                manageCollision(landingAudioClip, landingParticlesSystem);
                break;
            case "Explosion":
                playerHealth.TakeDamage(1);
                break;
            default:
                break;
        }
    }

    public void Die()
    {
        if (!isControllable) return;

        manageCollision(explosionAudioClip, explosionParticlesSystem);
    }

/// <summary>
/// Manages the collision response by disabling player control, stopping any ongoing audio, 
/// playing the specified audio clip and particle system, and disabling the PlayerMovement script to prevent further movement.
/// </summary>
/// <param name="audioClip"></param>
/// <param name="particleSystem"></param>
    void manageCollision(AudioClip audioClip, ParticleSystem particleSystem)
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
        particleSystem.Play();
        GetComponent<PlayerMovement>().enabled = false;
    }

}
