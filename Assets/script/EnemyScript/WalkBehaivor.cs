using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WalkBehaivor : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public GameObject Slime;
    public Vector3 position;

    float ChaseRange = 5;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        position = animator.GetComponent<SlimeScript>().positionSlime;
        //Debug.Log(position);

        agent.speed = 2;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(position);

        float distance = Vector3.Distance(animator.transform.position, player.position);

       

        if (animator.transform.position.x == position.x && animator.transform.position.z == position.z) // добавить условие, что y меньше высоты комнаты (если будет несколько этажей)
        {
            animator.SetBool("isIdle", true);
           
        }
        else
        {
            animator.SetBool("isIdle", false);
        }


        if (distance < ChaseRange)
        {
            animator.SetBool("isChasing", true);

        }



    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
