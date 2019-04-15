using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBaseFSM : StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject opponent;
    public NavMeshAgent agent;
    public float speed = 2.0f;
    public float rotSpeed = 1.0f;
    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        NPC = animator.gameObject;
        opponent = GameObject.FindGameObjectWithTag("Player");
        agent = NPC.GetComponent<NavMeshAgent>();
    }
}
