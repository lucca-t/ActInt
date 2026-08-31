using UnityEngine;
using TMPro; 

public class Barrel : MonoBehaviour
{
    public int health = 10;
    public TextMeshPro healthText; 
    
    public float fireRateBuff = 0.25f; 
    public GameObject explosionEffect;
    void Start()
    {
        UpdateText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            health -= 1;
            UpdateText();

            Destroy(other.gameObject); 

            if (health <= 0)
            {
                if (explosionEffect != null)
                {
                    Instantiate(explosionEffect, transform.position, Quaternion.identity);
                }
                Buff();
                Destroy(gameObject);
            }
        }
    }

    void UpdateText()
    {
        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }

    void Buff()
    {
        // encontrar todos los shoot scripts            esto bonus porque se enojo Unity
        Shoot[] allShooters = FindObjectsByType<Shoot>(FindObjectsInactive.Exclude);       

        foreach (Shoot shooter in allShooters)
        {
            shooter.fireRate -= fireRateBuff;

            // para no romper el juego  
            if (shooter.fireRate < 0.1f)
            {
                shooter.fireRate = 0.1f;
            }
        }
    }
}