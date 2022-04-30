using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : StateMachineBehaviour
{
    
    Transform player;
    float attackRange = 2;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance < attackRange)
        {
            animator.SetBool("isHit", false);
        }

        if (animator.GetComponent<SlimeScript>().death)
        {
            animator.SetBool("isDeath", true);
        }

        if (distance > attackRange)
        {
            animator.SetBool("isHit", false);
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
