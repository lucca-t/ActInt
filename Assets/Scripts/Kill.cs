using UnityEngine;

public class Kill : MonoBehaviour
{
    [SerializeField]
    private string targetTag = "Bullet"; 
    [SerializeField]
    private GameObject BulletImpact;

    public int health = 3;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            BulletDamage bullet = other.GetComponent<BulletDamage>();
            int damageToTake;
            if (bullet != null)
            {
                damageToTake = bullet.damage;
            }
            else
            {
                damageToTake = 1;
            }
            
            Vector3 hitPosition = other.transform.position;
            
            Destroy(other.gameObject);
            
            TakeDamage(damageToTake, hitPosition);
        }
    }

    // 3. Update the method to accept the position
    public void TakeDamage(int damage, Vector3 hitPosition)
    {
        health -= damage;
        
        if (BulletImpact != null)
        {
            GameObject impact = Instantiate(BulletImpact, hitPosition, Quaternion.identity);
            
            Destroy(impact, 0.2f);
        }

        if (health <= 0)
        {
            Destroy(gameObject); 
        }
    }
}