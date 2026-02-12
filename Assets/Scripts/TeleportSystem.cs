using UnityEngine;
using System.Collections;

public class TeleportSystem : MonoBehaviour
{
    [Header("Configurazione Movimento")]
    public float dashDuration = 0.2f; // Durata dello spostamento fluido
    public LayerMask groundLayer;    // Layer per identificare il pavimento
    
    [Header("Riferimenti")]
    public Transform playerTransform; // Il rig del giocatore (XR Rig o Camera)

    private bool _isTeleporting = false;

    void Update()
    {
        // TEST DESKTOP: Simula il puntamento con il mouse
        if (Input.GetMouseButtonDown(0) && !_isTeleporting)
        {
            PerformRaycast();
        }
    }

    private void PerformRaycast()
    {
        // Spara un raggio dalla telecamera verso la posizione del mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, groundLayer))
        {
            // Avvia la Coroutine per lo spostamento fluido
            StartCoroutine(TeleportRoutine(hit.point));
        }
    }

    private IEnumerator TeleportRoutine(Vector3 targetPosition)
    {
        _isTeleporting = true;
        Vector3 startPosition = playerTransform.position;
        
        // Manteniamo l'altezza del giocatore (Y) costante per evitare di "affondare" nel terreno
        targetPosition.y = startPosition.y; 

        float elapsedTime = 0;

        while (elapsedTime < dashDuration)
        {
            // Interpolazione lineare (LERP) per il movimento fluido
            playerTransform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / dashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        playerTransform.position = targetPosition;
        _isTeleporting = false;
    }
}