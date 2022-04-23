using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class idleBehaivor : StateMachineBehaviour
{
    
    Transform player;
    float ChaseRange = 5;
    


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance < ChaseRange)
        {
            animator.SetBool("isChasing", true);
          
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
