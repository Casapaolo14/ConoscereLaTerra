using UnityEngine;
using System;

public class StandObjective : MonoBehaviour
{
    // L'evento statico a cui tutti possono iscriversi
    // Il primo parametro è il nome dell'obiettivo, il secondo è la descrizione
    public static event Action<string> OnObjectiveCompleted;

    [SerializeField] private string nomeObiettivo = "Stand Agricoltura";
    private bool giaCompletato = false;

    // Metodo per attivare l'obiettivo
    public void CompletaObiettivo()
    {
        if (!giaCompletato)
        {
            giaCompletato = true;
            Debug.Log($"[Stand] Obiettivo '{nomeObiettivo}' completato!");
            
            // "Lancia" l'evento (notifica a tutti gli iscritti)
            OnObjectiveCompleted?.Invoke(nomeObiettivo);
        }
    }

    // Per il test Desktop senza VR: usiamo un trigger triggerato dal Player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CompletaObiettivo();
        }
    }
}