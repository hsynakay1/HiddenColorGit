using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints; 
    public float waitTime = 2f;
    public float speed = 2f;
    private Animator anim;

    private NavMeshAgent agent;
    private int currentWaypoint = 0;

    void Start () {
        agent = GetComponent<NavMeshAgent> ();
        anim = GetComponent<Animator>();
        MoveToNextWaypoint ();
    }

    void Update () {
        if (!agent.pathPending && agent.remainingDistance < 0.5f) {
            MoveToNextWaypoint ();
        }
        anim.SetBool("idle", agent.isStopped);
        anim.SetBool("Run", !agent.isStopped);
    }

    void MoveToNextWaypoint () {
        if (waypoints.Length > 0) {
            agent.destination = waypoints[currentWaypoint].position;
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            StartCoroutine (Wait ());
        }
    }

    IEnumerator Wait () {
        agent.isStopped = true;
        yield return new WaitForSeconds (waitTime);
        agent.isStopped = false;
    }
}
