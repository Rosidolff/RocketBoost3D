using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;

    [Header("Movement Settings")]
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float rotationForce = 2.5f;

    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem mainEngineParticles;
    [SerializeField] private ParticleSystem leftParticlesSystem;
    [SerializeField] private ParticleSystem rightParticlesSystem;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip ThrustAudioClip;



    Rigidbody rb;
    AudioSource audioSource;


    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

/// <summary>
/// Processes the rotation input by reading the rotation value from the input action. Depending on the value, it either rotates the player to the left, right, or stops the rotation. The Rigidbody's rotation is frozen to allow for manual rotation control.
/// </summary>
    private void ProcessRotation()
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        float rotationValue = rotation.ReadValue<float>();

        if (rotationValue < 0)
        {
            RotateRight();
        }
        else if (rotationValue > 0)
        {
            RotateLeft();
        }
        else
        {
            StopRotation();
        }
    }

/// <summary>
/// Stops the rotation of the player by stopping both the left and right particle systems, providing visual feedback that the player is no longer rotating.
/// </summary>
    private void StopRotation()
    {
        leftParticlesSystem.Stop();
        rightParticlesSystem.Stop();
    }

/// <summary>
/// Rotates the player to the left by applying a rotation around the forward axis. It also manages the particle systems for visual feedback, stopping the right particle system and playing the left particle system when rotating left.
/// </summary>
    private void RotateLeft()
    {
        transform.Rotate(Vector3.back * rotationForce * Time.deltaTime);
        if (!leftParticlesSystem.isPlaying)
        {
            rightParticlesSystem.Stop();
            leftParticlesSystem.Play();
        }
    }

/// <summary>
/// Rotates the player to the right by applying a rotation around the forward axis. It also manages the particle systems for visual feedback, stopping the left particle system and playing the right particle system when rotating right.
/// </summary>
    private void RotateRight()
    {
        transform.Rotate(Vector3.forward * rotationForce * Time.deltaTime);
        if (!rightParticlesSystem.isPlaying)
        {
            leftParticlesSystem.Stop();
            rightParticlesSystem.Play();
        }
    }

/// <summary>
/// Processes the thrust input by checking if the thrust action is pressed. If it is pressed, it starts the thrusting action; otherwise, it stops the thrusting action.
/// </summary>
    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

/// <summary>
/// Stops the thrusting action by stopping the main engine particle system and audio source.
/// </summary>
    private void StopThrusting()
    {        
        mainEngineParticles.Stop();
        audioSource.Stop();
    }

/// <summary>
/// Starts the thrusting action by applying a relative force to the Rigidbody, playing the main engine particle system, and playing the thrust audio clip if they are not already playing.
/// </summary>
    private void StartThrusting()
    {
        
        rb.AddRelativeForce(Vector3.up * moveForce);

        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(ThrustAudioClip);
        }

    }
}