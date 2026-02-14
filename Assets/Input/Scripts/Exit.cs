using UnityEngine;
using UnityEngine.InputSystem;

public class Exit : MonoBehaviour
{
    public void OnEsc()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        
        Debug.Log("Выход из игры!");
    }
}