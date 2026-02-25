using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Se esiste già una copia di me, distruggi questa nuova
            Destroy(gameObject);
        }

        // Forza l'oggetto a uscire da eventuali padri (necessario per DontDestroyOnLoad)
        transform.SetParent(null);
        
        DontDestroyOnLoad(gameObject);
        
        Debug.Log("L'oggetto " + gameObject.name + " è ora persistente!");
    }
}