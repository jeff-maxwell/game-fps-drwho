using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DalekController : MonoBehaviour
{
    private NavMeshAgent dalek;
    private float initSpeed = 3.5f;

    void Start()
    {
        dalek = this.GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Vector3 target)
    {
        dalek.SetDestination(target);
        dalek.speed = initSpeed;
        dalek.isStopped = false;
    }

    public void SetTarget(Vector3 target)
    {
        dalek.SetDestination(target);
        if (dalek.remainingDistance < 5f)
        {
            dalek.isStopped = true;
        }
        else
        {
            dalek.isStopped = false;
            dalek.speed = 5f;
        }
    }

    public Vector3 GetDestination()
    {
        return dalek.destination;
    }
    
    public NavMeshAgent GetNavMeshAgent()
    {
        return dalek;
    }
}
