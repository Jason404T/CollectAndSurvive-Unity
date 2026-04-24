using TMPro;
using UnityEngine;

// Este script se encarga únicamente de actualizar la interfaz
// relacionada con los pickups y la victoria.
public class PickupUI : MonoBehaviour
{
    // Referencia al texto que muestra el contador de pickups.
    [SerializeField] private TextMeshProUGUI pickupText;

    // Referencia al objeto de texto que muestra el mensaje de victoria.
    [SerializeField] private GameObject winText;

    // Referencia al script que contiene la lógica de recolección.
    [SerializeField] private PickupCollector pickupCollector;

    // Este método se ejecuta cuando el objeto se activa.
    private void OnEnable()
    {
        // Si existe el PickupCollector, nos suscribimos al evento.
        if (pickupCollector != null)
        {
            pickupCollector.OnPickupCountChanged += UpdateUI;
        }
    }

    // Este método se ejecuta cuando el objeto se desactiva.
    private void OnDisable()
    {
        // Nos desuscribimos del evento para evitar referencias colgantes.
        if (pickupCollector != null)
        {
            pickupCollector.OnPickupCountChanged -= UpdateUI;
        }
    }

    // Start se ejecuta una vez al iniciar la escena.
    private void Start()
    {
        // Ocultamos el texto de victoria al inicio.
        if (winText != null)
        {
            winText.SetActive(false);
        }

        // Forzamos una actualización inicial por seguridad.
        UpdateUI();
    }

    // Este método actualiza el contador en pantalla
    // y muestra el mensaje de victoria si corresponde.
    private void UpdateUI()
    {
        // Actualizamos el texto del contador.
        if (pickupCollector != null && pickupText != null)
        {
            pickupText.text = "Pickups: " +
                              pickupCollector.PickupsCollected +
                              " / " +
                              pickupCollector.TotalPickups;
        }

        // Si ya se recogieron todos los pickups, mostramos el mensaje de victoria.
        if (pickupCollector != null && winText != null && pickupCollector.HasCollectedAllPickups)
        {
            winText.SetActive(true);
        }
    }
}