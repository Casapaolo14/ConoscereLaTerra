using UnityEngine;
using UnityEngine.Pool;

public class PooledObject : MonoBehaviour
{
    public IObjectPool<GameObject> myPool;

    public void Deactivate()
    {
        myPool.Release(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Torna nel pool quando tocca terra
        Deactivate();
    }
}