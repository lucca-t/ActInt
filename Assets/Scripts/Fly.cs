using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField]
    private float speed = 60.0f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
