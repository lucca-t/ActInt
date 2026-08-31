using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    public GameObject gameOverScreen; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Transform playerRoot = transform.root;

            if (playerRoot.childCount <= 3)
            {   
                if (gameOverScreen != null)
                {
                    gameOverScreen.SetActive(true);
                }
                Time.timeScale = 0f; 
                return;
            }

            for (int i = 0; i < playerRoot.childCount; i++)
            {
                Transform child = playerRoot.GetChild(i);
                if (child.CompareTag("Player"))
                {
                    Destroy(child.gameObject);
                    break;
                }
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}   