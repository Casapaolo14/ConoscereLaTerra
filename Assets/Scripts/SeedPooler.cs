using UnityEngine;
using UnityEngine.Pool; // Libreria fondamentale

public class SeedPooler : MonoBehaviour
{
    public GameObject seedPrefab;
    private IObjectPool<GameObject> _pool;

    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 50;

    private void Awake()
    {
        // Inizializzazione del Pool
        _pool = new ObjectPool<GameObject>(
            CreateSeed,           // Funzione per creare l'oggetto
            OnTakeFromPool,       // Azione quando l'oggetto viene "pescato"
            OnReturnedToPool,     // Azione quando l'oggetto torna nel pool
            OnDestroyPoolObject,  // Azione se il pool supera la dimensione massima
            collectionCheck: true,
            defaultCapacity,
            maxSize
        );
    }

    // 1. Crea fisicamente il prefab
    private GameObject CreateSeed()
    {
        GameObject seed = Instantiate(seedPrefab);
        // Aggiungiamo un riferimento al pooler nel seme per farlo tornare indietro
        seed.AddComponent<PooledObject>().myPool = _pool;
        return seed;
    }

    // 2. Attiva l'oggetto quando serve
    private void OnTakeFromPool(GameObject seed) => seed.SetActive(true);

    // 3. Disattiva l'oggetto invece di distruggerlo
    private void OnReturnedToPool(GameObject seed) => seed.SetActive(false);

    private void OnDestroyPoolObject(GameObject seed) => Destroy(seed);

    // Metodo pubblico per "sparare" un seme
    public void SpawnSeed(Vector3 position, Quaternion rotation)
    {
        GameObject seed = _pool.Get();
        seed.transform.position = position;
        seed.transform.rotation = rotation;
    }
}