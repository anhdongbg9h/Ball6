using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dizzy : StateMachineBehaviour
{
    public float timer;
    private float time;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.GetComponent<Boss1>().number = 1;
        animator.transform.GetComponent<Boss1>().isDizzy = true;
        time = timer;
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (time <= 0)
        {
            animator.SetTrigger("dizzyToIdle");
        }
        else
        {
            time -= Time.deltaTime;
        }
        if (animator.transform.GetComponent<Boss1>().hp == 0)
        {
            animator.SetTrigger("isDie");
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.GetComponent<Boss1>().isDizzy = false;
    }
}
