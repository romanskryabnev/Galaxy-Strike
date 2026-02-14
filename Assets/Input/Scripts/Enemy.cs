using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] GameObject hitVFX; 
    [SerializeField] AudioClip hitSound; 
    Scoreboard scoreboard;
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {   Instantiate(hitVFX, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
        hitPoints--;
        if (hitPoints <= 0)
        {   
            scoreboard.AddScore(10);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
} 