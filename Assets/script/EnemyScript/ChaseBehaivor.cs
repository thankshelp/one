using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaivor : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float attackRange = 2;
    float ChaseRange = 5;
    


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 4;
        

       player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, player.position);

        agent.SetDestination(player.position);



        if (distance < attackRange)
        {
            animator.SetBool("isAttack", true);
        }

        if (distance > ChaseRange)
        {
            animator.SetBool("isChasing", false);

        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        
    }

}
