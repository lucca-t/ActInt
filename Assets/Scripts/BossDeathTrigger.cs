using UnityEngine;

public class BossDeathTrigger : MonoBehaviour
{
    public GameObject gameOverScreen; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
            }
            Time.timeScale = 0f; 
        }
    }
}