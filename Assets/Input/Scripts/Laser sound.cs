using UnityEngine;

public class LaserSound : MonoBehaviour
{
    public AudioClip laserSound;
    private AudioSource audioSource;
    private ParticleSystem particles;
    
    private float shootTimer = 0f;
    private float shootInterval;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();
        shootInterval = 1f / particles.emission.rateOverTime.constant;
    }
    
    void Update()
    {
        bool isEmitting = particles.emission.enabled;
        
        if (isEmitting)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootInterval)
            {
                audioSource.PlayOneShot(laserSound);
                shootTimer = 0f;
            }
        }
        else
        {
            shootTimer = 0f;
        }
        
    }
}