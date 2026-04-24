using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Este script se encarga de la lógica general del nivel,
// como reiniciar la escena cuando el jugador gana o pierde.
public class LevelManager : MonoBehaviour
{
    // Referencia al script que sabe si el jugador ya recogió todos los pickups.
    [SerializeField] private PickupCollector pickupCollector;

    // Referencia al script que controla el movimiento del jugador.
    [SerializeField] private PlayerMover playerMover;

    // Bandera para evitar reinicios múltiples al mismo tiempo.
    private bool isRestarting = false;

    // Bandera para no repetir la lógica de victoria varias veces.
    private bool hasHandledWin = false;

    // Update se ejecuta una vez por frame.
    private void Update()
    {
        // Si falta alguna referencia importante, salimos.
        if (pickupCollector == null || playerMover == null)
        {
            return;
        }

        // Si el jugador ya ganó y todavía no hemos procesado la victoria...
        if (pickupCollector.HasCollectedAllPickups && !hasHandledWin)
        {
            HandleWin();
        }

        // Si el jugador ya ganó y presiona R, reiniciamos el nivel.
        if (pickupCollector.HasCollectedAllPickups && Input.GetKeyDown(KeyCode.R))
        {
            RestartCurrentScene();
        }
    }

    // Este método se ejecuta una sola vez cuando el jugador gana.
    private void HandleWin()
    {
        // Marcamos que ya procesamos la victoria.
        hasHandledWin = true;

        // Desactivamos el movimiento del jugador para que no siga moviéndose.
        playerMover.enabled = false;
    }

    // Método público para que otros sistemas, como el enemigo,
    // puedan pedir el reinicio del nivel tras un golpe.
    public void RestartLevelFromEnemyHit()
    {
        // Evitamos ejecutar varios reinicios al mismo tiempo.
        if (!isRestarting)
        {
            StartCoroutine(RestartAfterDelay(0.75f));
        }
    }

    // Coroutine para esperar un pequeño tiempo antes de reiniciar.
    private IEnumerator RestartAfterDelay(float delay)
    {
        // Marcamos que ya estamos en proceso de reinicio.
        isRestarting = true;

        // Desactivamos el movimiento del jugador durante la pausa,
        // para que no siga desplazándose justo antes del reinicio.
        if (playerMover != null)
        {
            playerMover.enabled = false;
        }

        // Esperamos la cantidad de segundos indicada.
        yield return new WaitForSeconds(delay);

        // Reiniciamos la escena actual.
        RestartCurrentScene();
    }

    // Método privado que encapsula la recarga de la escena actual.
    private void RestartCurrentScene()
    {
        // Obtenemos la escena activa.
        Scene currentScene = SceneManager.GetActiveScene();

        // Recargamos la misma escena.
        SceneManager.LoadScene(currentScene.name);
    }
}