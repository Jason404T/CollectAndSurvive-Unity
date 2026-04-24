using UnityEngine;

// Este script va en el enemigo.
// Su responsabilidad es detectar cuando el jugador entra en contacto
// con el enemigo y notificar al LevelManager para reiniciar el nivel.
public class EnemyCollision : MonoBehaviour
{
    // Referencia al LevelManager, que se encargará de reiniciar la escena.
    [SerializeField] private LevelManager levelManager;

    // Este método se ejecuta cuando otro collider entra en este trigger.
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que entró tiene el tag "Player".
        if (other.CompareTag("Player"))
        {
            // Si existe LevelManager, pedimos reiniciar el nivel.
            if (levelManager != null)
            {
                levelManager.RestartLevelFromEnemyHit();
            }
        }
    }
}