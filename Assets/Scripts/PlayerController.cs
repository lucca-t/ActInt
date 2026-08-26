using UnityEngine;

/// <summary>
/// Clase para controlar el movimiento lateral del jugador.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float xBound = 10.0f; // Límite de movimiento en el eje X

    /// <summary>
    /// Este método se llama una vez por frame.
    /// </summary>
    void Update()
    {
        // Obtener el input horizontal por defecto
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Mover el objeto de lado a lado
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Limitar la posición en el eje X para que no pase de -10 ni de 10
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -xBound, xBound);
        transform.position = currentPosition;
    }
}