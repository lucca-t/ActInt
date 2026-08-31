using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Required for loading scenes
using System.Collections;          // Required for Coroutines

public class GameManager : MonoBehaviour
{
    public GameObject victoryScreen;
    public Transform playerRoot; 
    public TextMeshProUGUI soldierCounterText; 

    // Set this to match the length of your restart button sound effect
    public float delayBeforeRestart = 0.5f;

    private bool gameWon = false;

    void Update()
    {
        if (playerRoot != null && soldierCounterText != null)
        {
            int soldierCount = playerRoot.childCount - 2;
            soldierCounterText.text = "Soldiers: " + soldierCount; 
        }

        if (!gameWon)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            if (enemies.Length == 0)
            {
                TriggerVictory();
            }
        }
    }

    void TriggerVictory()
    {
        gameWon = true;
        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
        }
        
        Time.timeScale = 0f; 
    }

    public void RestartGame()
    {
        StartCoroutine(RestartWithDelay());
    }

    private IEnumerator RestartWithDelay()
    {
        // Para que se escuche el audio
        yield return new WaitForSecondsRealtime(delayBeforeRestart);
        
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}