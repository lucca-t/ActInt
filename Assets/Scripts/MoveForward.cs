using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public int speed = 10;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
