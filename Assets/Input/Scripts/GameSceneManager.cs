using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class GameSceneManager : MonoBehaviour
{   public PlayableDirector timeline;
    public void RestartScene()
    {
        StartCoroutine(RestartSceneRoutine());
    }
    IEnumerator RestartSceneRoutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(
        SceneManager.GetActiveScene().name);
    }
    
    public void endGame()
    {  Debug.Log("END!");
        Application.Quit();
    }

    

}
