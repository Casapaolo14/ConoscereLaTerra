using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VirtualAIAgentController : MonoBehaviour
{

    [Header("TargetsList")]
    public List<Transform> targets;
    public float speed = 3.0f;
    public float stopDistance = 0.5f;

    public NavMeshAgent Agent;

    private Transform currentTarget;
    
    void Start()
    {
        SetRandomTarget();
    }

    void Update()
    {
        if (currentTarget == null) return;

        Agent.SetDestination(currentTarget.position);

        // 4. Cambio target quando arrivato
        if (Vector3.Distance(transform.position, currentTarget.position) < stopDistance)
        {
            SetRandomTarget();
        }
    }

    void SetRandomTarget()
    {
        if (targets != null && targets.Count > 0)
        {
            currentTarget = targets[Random.Range(0, targets.Count)];
        }
    }
}
