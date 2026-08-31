using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject victoryScreen;
    public Transform playerRoot; 
    public TextMeshProUGUI soldierCounterText; 

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
}