using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Required for Coroutines

public class MainMenu : MonoBehaviour
{
    public string gameSceneName = "MainScene"; 
    
    public float delayBeforeLoading = 0.3f; 

    public void PlayGame()
    {
        Time.timeScale = 1f; 
        
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        // Para que suene el audio
        yield return new WaitForSeconds(delayBeforeLoading);
        
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;    
        }
}