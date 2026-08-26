using UnityEngine;

public class Kill : MonoBehaviour
{
    [SerializeField]
   private string targetTag = "Bullet"; 
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            gameObject.SetActive(false);
        }
    }
}

