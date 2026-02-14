using UnityEngine; 
using UnityEngine.Playables;
 public class Boss : MonoBehaviour 
 {
     
     public PlayableDirector timeline;
    void OnDestroy() 
      {
         timeline.Resume(); 
      } 
}