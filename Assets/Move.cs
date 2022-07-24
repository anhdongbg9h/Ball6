using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : StateMachineBehaviour
{
    public float speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.GetComponent<Boss1>().isMoveLeft)
        {
            animator.transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
        else
        {
            animator.transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
