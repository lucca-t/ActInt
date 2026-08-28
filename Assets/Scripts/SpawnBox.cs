using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [SerializeField]
    private GameObject SoldierBox;

    [SerializeField]
    private float fireRate = 0.5f;

    [SerializeField]
    private float bulletLifetime = 6f;

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

        GameObject box = Instantiate(SoldierBox, transform.position, Quaternion.identity);

        // despawnear el enemigo
        Destroy(box, bulletLifetime);
    }
}
