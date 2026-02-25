using UnityEngine;
using UnityEngine.InputSystem; // Necessario per il nuovo Input System

public class XRIToggleTablet : MonoBehaviour
{
    [Header("Riferimenti")]
    public GameObject oggettoDaAttivare; // L'oggetto da accendere/spegnere
    public InputActionReference toggleReference; // Il riferimento al tasto A

    private void OnEnable()
    {
        // Ci iscriviamo all'evento "performed" (quando il tasto viene premuto)
        toggleReference.action.performed += Toggle;
    }

    private void OnDisable()
    {
        // Rimuoviamo l'iscrizione per evitare errori di memoria
        toggleReference.action.performed -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        if (oggettoDaAttivare != null)
        {
            // Inverte lo stato attuale (se è true diventa false, e viceversa)
            bool isActive = oggettoDaAttivare.activeSelf;
            oggettoDaAttivare.SetActive(!isActive);
        }
    }
}