using UnityEngine;

public class InkyEscapeState : GhostBaseState
{
    GameObject blinky;

    private void InkyEscape()
    {
        if (blinky == null)
        {
            blinky = GameObject.Find("Blinky");
        }

        ghost.SetMoveToLocation(
            ghost.PacMan.position * 2 - blinky.transform.position
        );
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        InkyEscape();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (nextActionTime < gapTime)
        {
            nextActionTime += Time.deltaTime;
        }
        else
        {
            nextActionTime = 0;
            InkyEscape();
        }
    }
}
