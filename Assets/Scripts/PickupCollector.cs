using System;
using UnityEngine;

// Este script va en el Player.
// Su responsabilidad es detectar pickups, llevar el conteo
// y notificar cuando ese conteo cambia.
public class PickupCollector : MonoBehaviour
{
    // Evento que otros scripts pueden escuchar.
    // Lo lanzaremos cada vez que cambie la cantidad de pickups recogidos.
    public event Action OnPickupCountChanged;

    // Cantidad de pickups recogidos hasta el momento.
    private int pickupsCollected = 0;

    // Cantidad total de pickups existentes al iniciar la escena.
    private int totalPickups = 0;

    // Propiedad pública solo de lectura para exponer
    // cuántos pickups se han recogido.
    public int PickupsCollected => pickupsCollected;

    // Propiedad pública solo de lectura para exponer
    // cuántos pickups hay en total.
    public int TotalPickups => totalPickups;

    // Esta propiedad indica si ya se recogieron todos los pickups.
    public bool HasCollectedAllPickups => totalPickups > 0 && pickupsCollected >= totalPickups;

    // Start se ejecuta una vez al comenzar la escena.
    private void Start()
    {
        // Contamos todos los objetos de la escena que tengan el tag "Pickup".
        totalPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

        // Notificamos una vez al inicio para que la UI pueda mostrar
        // correctamente el valor inicial, por ejemplo 0 / 4.
        OnPickupCountChanged?.Invoke();
    }

    // Este método se ejecuta cuando el Player entra en un trigger.
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto tocado tiene el tag "Pickup".
        if (other.CompareTag("Pickup"))
        {
            // Aumentamos el contador.
            pickupsCollected++;

            // Mostramos el progreso en la consola para depuración.
            Debug.Log("Pickups collected: " + pickupsCollected + " / " + totalPickups);

            // Eliminamos el pickup de la escena.
            Destroy(other.gameObject);

            // Notificamos que el contador cambió.
            OnPickupCountChanged?.Invoke();
        }
    }
}