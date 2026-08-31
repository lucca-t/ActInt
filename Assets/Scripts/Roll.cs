using UnityEngine;

public class Roll : MonoBehaviour
{
    
    [SerializeField]
    private float rotationSpeed = 180.0f; 

    void Update()
    {        
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}