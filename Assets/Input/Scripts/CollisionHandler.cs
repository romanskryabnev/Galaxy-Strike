using UnityEngine;
using System.Collections;



public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    GameSceneManager gameSceneManager;
    void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    
    void OnTriggerEnter(Collider other)
    {  if (other.gameObject.tag == "Enemy")
        {   gameSceneManager.RestartScene();
        
        if (destroyedVFX != null)
        {
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
        }
    }
    
}