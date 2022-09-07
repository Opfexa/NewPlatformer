using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackBehaviour : StateMachineBehaviour
{
    private PlayerController player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<PlayerController>();
        player.playerAttackScript.onFight = true;
        animator.SetBool("onFight",true);
        player.playerAttackScript.sCombo = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(player.playerAttackScript.sCombo == 0)
        {
            animator.SetBool("sCombo",false);
        }
        else if(player.playerAttackScript.sCombo == 1)
        {
            animator.SetBool("sCombo",true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("sAttack");
        animator.ResetTrigger("pAttack");
        animator.ResetTrigger("mAttack");
        animator.ResetTrigger("kAttack");
        animator.ResetTrigger("bAttack");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
