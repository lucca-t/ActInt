using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private float fireRate = 0.5f;

    [SerializeField]
    private float bulletLifetime = 6f;

    private float clusterRadius = 5f;

    private float nextFireTime = 0f;

    void Update()
    {
        // Reusando el codigo para disparar bala pero
        // con random offset para spawnear a los enemigos

        // checar si se puede disparar de nuevo
        if (Time.time >= nextFireTime)
        {
            Fire();
            // resetear el tiempo
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        // crear una enemigo pero en position random
        Vector3 randomOffset = Random.insideUnitSphere * clusterRadius;
        randomOffset.y = 0; 
        
        // Spawn them around whoever hit the box (the player OR the clone)
        Vector3 spawnPosition = transform.position + randomOffset;

        GameObject enemy = Instantiate(Enemy, spawnPosition, Quaternion.identity);

        // despawnear el enemigo
        Destroy(enemy, bulletLifetime);
    }
}
