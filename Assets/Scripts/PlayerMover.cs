using UnityEngine;

// Este script controla el movimiento del jugador usando Rigidbody.
// Es una mejor práctica que mover el objeto directamente con Transform
// cuando el objeto ya tiene un Rigidbody.
public class PlayerMover : MonoBehaviour
{
    // Velocidad de movimiento del jugador, editable desde el Inspector.
    [SerializeField] private float moveSpeed = 5f;

    // Referencia al Rigidbody del jugador.
    private Rigidbody rb;

    // Variable donde guardamos la dirección de movimiento leída del input.
    private Vector3 movementInput;

    // Awake se ejecuta antes de Start.
    // Aquí obtenemos referencias a componentes necesarios.
    private void Awake()
    {
        // Guardamos la referencia al Rigidbody del mismo objeto.
        rb = GetComponent<Rigidbody>();
    }

    // Update se ejecuta una vez por frame.
    // Aquí leemos el input del jugador.
    private void Update()
    {
        // Leemos el eje horizontal:
        // A / izquierda = -1
        // D / derecha   =  1
        float horizontal = Input.GetAxis("Horizontal");

        // Leemos el eje vertical:
        // S / abajo = -1
        // W / arriba = 1
        float vertical = Input.GetAxis("Vertical");

        // Guardamos la dirección deseada en el plano XZ.
        // Y se mantiene en 0 porque no queremos movimiento vertical.
        movementInput = new Vector3(horizontal, 0f, vertical);
    }

    // FixedUpdate se ejecuta en intervalos fijos.
    // Es el lugar recomendado para movimiento relacionado con físicas.
    private void FixedUpdate()
    {
        // Calculamos la nueva posición usando la posición actual
        // más el movimiento deseado, la velocidad y el delta de tiempo físico.
        Vector3 newPosition = rb.position + movementInput * moveSpeed * Time.fixedDeltaTime;

        // Movemos el Rigidbody a la nueva posición.
        rb.MovePosition(newPosition);
    }
}