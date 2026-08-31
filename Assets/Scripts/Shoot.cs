using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private GameObject MuzzleFlash;

    [SerializeField]
    public float fireRate = 0.5f;

    [SerializeField]
    private float bulletLifetime = 6f;

    private float nextFireTime = 0f;

    public Transform firePoint;

    void Start()
    {
        // agregar delay para que no disparen al mismo tiempo
        nextFireTime = Time.time + Random.Range(0f, fireRate);
    }

    void Update()
    {
        // checar si se puede disparar de nuevo
        if (Time.time >= nextFireTime)
        {
            Fire();
            // resetear el tiempo
            nextFireTime = Time.time + fireRate + Random.Range(0f, 0.1f);
        }
    }

    void Fire()
    {   
        Vector3 spawnPosition = firePoint.position + (firePoint.forward * 0.2f);
        // crear una bala
        GameObject bullet = Instantiate(BulletPrefab, spawnPosition, Quaternion.identity);
        // crear muzzle flash
        GameObject flash = Instantiate(MuzzleFlash, spawnPosition, Quaternion.identity, firePoint);
        // despawnear la bala
        Destroy(bullet, bulletLifetime);
        Destroy(flash, 0.1f);
    }
}
