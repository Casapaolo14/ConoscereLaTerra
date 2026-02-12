using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Istanza statica accessibile da qualsiasi altro script
    public static GameManager Instance { get; private set; }

    [Header("Progresso Utente")]
    public int obiettiviCompletati = 0;
    public bool tutorialFinito = false;
    public string badgeAssegnato = "Nessuno";

    private void Awake()
    {
        // Logica Singleton: ne esiste solo uno
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        // Impedisce che l'oggetto venga distrutto cambiando scena
        DontDestroyOnLoad(gameObject);
    }

    public void AggiungiProgresso()
    {
        obiettiviCompletati++;
        Debug.Log($"[GameManager] Obiettivo completato! Totale: {obiettiviCompletati}");
    }
}