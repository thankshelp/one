using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaivor : StateMachineBehaviour
{
    Transform player;
    


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance > 2)
        {
            animator.SetBool("isAttack", false);
        }

        if (animator.GetComponent<SlimeScript>().attaked)
        {
            animator.SetBool("isHit", true);
            
            animator.GetComponent<SlimeScript>().attaked = false;
        }
        
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
