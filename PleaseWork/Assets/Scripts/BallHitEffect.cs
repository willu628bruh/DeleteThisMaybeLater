using UnityEngine;

public class BallHitEffect : MonoBehaviour
{
    public ParticleSystem hitEffect;
    public AudioClip hitSound;

    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.15f;

    private AudioSource audioSource;
    private CameraShake camShake;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Find camera shake script
        camShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Optional: only trigger on strong hits
            if (collision.relativeVelocity.magnitude > 3f)
            {
                ContactPoint contact = collision.contacts[0];

                // Particle effect
                ParticleSystem effect = Instantiate(hitEffect, contact.point, Quaternion.identity);
                effect.transform.rotation = Quaternion.LookRotation(contact.normal);
                Destroy(effect.gameObject, effect.main.duration);

                // Sound
                if (hitSound != null)
                {
                    AudioSource.PlayClipAtPoint(hitSound, contact.point);
                }

                // Camera shake
                if (camShake != null)
                {
                    StartCoroutine(camShake.Shake(shakeDuration, shakeMagnitude));
                }
            }
        }
    }
}