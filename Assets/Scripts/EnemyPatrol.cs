using UnityEngine;

// Este script mueve un enemigo entre dos puntos,
// creando una patrulla simple de ida y vuelta.
public class EnemyPatrol : MonoBehaviour
{
    // Primer punto de patrulla.
    [SerializeField] private Transform pointA;

    // Segundo punto de patrulla.
    [SerializeField] private Transform pointB;

    // Velocidad de movimiento del enemigo.
    [SerializeField] private float moveSpeed = 2f;

    // Punto objetivo actual hacia el que se mueve el enemigo.
    private Transform currentTarget;

    // Distancia mínima para considerar que ya llegó al punto.
    private const float ReachDistance = 0.1f;

    // Start se ejecuta una vez al iniciar la escena.
    private void Start()
    {
        // Al comenzar, hacemos que el enemigo se dirija al primer punto.
        currentTarget = pointA;
    }

    // Update se ejecuta una vez por frame.
    private void Update()
    {
        // Si falta alguno de los puntos, no hacemos nada.
        if (pointA == null || pointB == null || currentTarget == null)
        {
            return;
        }

        // Movemos al enemigo hacia el punto objetivo actual.
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget.position,
            moveSpeed * Time.deltaTime
        );

        // Revisamos si ya está suficientemente cerca del punto objetivo.
        if (Vector3.Distance(transform.position, currentTarget.position) <= ReachDistance)
        {
            // Si estaba yendo al punto A, ahora va al punto B.
            // Si estaba yendo al punto B, ahora va al punto A.
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }
}