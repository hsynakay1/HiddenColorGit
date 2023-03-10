using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathMover : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Queue<Vector3> _pathPoints = new Queue<Vector3>();
    public Animator anim;
    private PathCreator _pathCreator;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _pathCreator = FindObjectOfType<PathCreator>();
        _pathCreator.OnNewPathCreated += SetPoints;
    }

    private void SetPoints(IEnumerable<Vector3> points)
    {
        _pathPoints = new Queue<Vector3>(points);
    }

    private void Update()
    {
        UpdatePathing();
    }

    private void UpdatePathing()
    {
        if (ShouldSetDestination())
        {
            
            _navMeshAgent.SetDestination(_pathPoints.Dequeue());
            if (_pathPoints.Count == 0)
            {
                anim.SetBool("idle",true);
                anim.SetBool("Run",false);
            }
            else
            {
                anim.SetBool("Run",true);
                anim.SetBool("idle",false);
            }
        }
    }

    private bool ShouldSetDestination()
    {
        if (_pathPoints.Count == 0) return false;
        if (_navMeshAgent.hasPath == false || _navMeshAgent.remainingDistance < .5f) return true;

        return false;
    }
}
