using UnityEngine;
using System.Collections.Generic;

public class SimpleFollower : MonoBehaviour
{
    [Header("Configurazione")]
    public List<Transform> targets;
    public float speed = 3.0f;
    public float stopDistance = 0.5f;
    
    [Header("Evitamento Bot")]
    public float avoidanceRadius = 1.5f; 
    public float avoidanceForce = 2.0f;  

    private Transform currentTarget;

    void Start()
    {
        SetRandomTarget();
    }

    void Update()
    {
        if (currentTarget == null) return;

        // 1. Direzione verso il target
        Vector3 directionToTarget = (currentTarget.position - transform.position).normalized;

        // 2. Calcolo Evitamento
        Vector3 avoidanceDirection = CalculateAvoidance();

        // 3. Somma delle direzioni
        Vector3 finalDirection = (directionToTarget + avoidanceDirection * avoidanceForce).normalized;
        
        // Movimento
        transform.position += finalDirection * speed * Time.deltaTime;

        // Rotazione fluida verso la direzione di marcia
        if (finalDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(finalDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        // 4. Cambio target quando arrivato
        if (Vector3.Distance(transform.position, currentTarget.position) < stopDistance)
        {
            SetRandomTarget();
        }
    }

    Vector3 CalculateAvoidance()
    {
        Vector3 avoidance = Vector3.zero;
        Collider[] closeObjects = Physics.OverlapSphere(transform.position, avoidanceRadius);

        foreach (var col in closeObjects)
        {
            if (col.gameObject != this.gameObject)
            {
                // Applica l'evitamento solo se l'altro oggetto ha questo stesso script
                if (col.GetComponent<SimpleFollower>() != null)
                {
                    Vector3 diff = transform.position - col.transform.position;
                    // Più sono vicini, più la forza è intensa
                    avoidance += diff.normalized / Mathf.Max(diff.magnitude, 0.1f);
                }
            }
        }
        return avoidance;
    }

    void SetRandomTarget()
    {
        if (targets != null && targets.Count > 0)
        {
            currentTarget = targets[Random.Range(0, targets.Count)];
        }
    }

    // Correzione errore CS0117: 'D' maiuscola
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, avoidanceRadius);
    }
}