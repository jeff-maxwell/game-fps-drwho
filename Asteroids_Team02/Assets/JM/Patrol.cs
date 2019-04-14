﻿using UnityEngine;

public class Patrol : NPCBaseFSM
{
    GameObject[] waypoints;
    int currentWP;
 
    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        int randomWP = Random.Range(0, waypoints.Length - 1);
        currentWP = randomWP;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;

        if (Vector3.Distance(waypoints[currentWP].transform.position,
                    NPC.transform.position) < 3.0f)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        //agent.SetDestination(waypoints[currentWP].transform.position);

        var direction = waypoints[currentWP].transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,
                            Quaternion.LookRotation(direction),
                            1.0f * Time.deltaTime);
        NPC.transform.Translate(0, 0, Time.deltaTime * 2.0f);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
