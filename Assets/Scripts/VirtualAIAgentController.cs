using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VirtualAIAgentController : MonoBehaviour
{
    [Header("Targets List")]
    public List<Transform> targets;
    public float stopDistance = 0.5f;

    public NavMeshAgent agent; // Minuscolo è best practice

    private Transform currentTarget;
    
    void Start()
    {
        // Se non hai assegnato l'agente nell'inspector, prova a prenderlo qui
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        
        agent.stoppingDistance = stopDistance;
        SetRandomTarget();
    }

    void Update()
    {
        if (currentTarget == null) return;

        // CONTROLLO ARRIVO: 
        // pathPending: sta ancora calcolando?
        // remainingDistance: quanto manca?
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Se l'agente non ha un percorso o è quasi fermo, cambia target
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                SetRandomTarget();
            }
        }
    }

    void SetRandomTarget()
    {
        if (targets != null && targets.Count > 0)
        {
            // Scegliamo un target a caso
            currentTarget = targets[Random.Range(0, targets.Count)];
            
            // IMPOSTIAMO LA DESTINAZIONE UNA VOLTA SOLA
            agent.SetDestination(currentTarget.position);
        }
    }
}