using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;

    [SerializeField]
    private float fireRate = 0.5f;

    [SerializeField]
    private float bulletLifetime = 6f;

    private float nextFireTime = 0f;

    void Update()
    {
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
        // crear una bala
        GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);

        // despawnear la bala
        Destroy(bullet, bulletLifetime);
    }
}
