using UnityEngine;

// Este script hace que la cámara siga a un objetivo
// manteniendo siempre la misma distancia relativa.
public class CameraFollow : MonoBehaviour
{
    // Referencia al objeto que la cámara debe seguir.
    [SerializeField] private Transform target;

    // Guarda la distancia entre la cámara y el objetivo.
    private Vector3 offset;

    // Start se ejecuta una vez al iniciar la escena.
    private void Start()
    {
        // Calculamos el offset inicial entre la cámara y el objetivo.
        // Así respetamos la posición en la que acomodaste la cámara manualmente.
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    // LateUpdate se ejecuta después de Update.
    // Se usa mucho en cámaras para que sigan al jugador
    // después de que el jugador ya se movió en ese frame.
    private void LateUpdate()
    {
        // Si existe un objetivo asignado, actualizamos la posición de la cámara.
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}