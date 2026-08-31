using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float xBound = 10.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -xBound, xBound);
        transform.position = currentPosition;
    }
}