using UnityEngine;

public class GhostDeathState : GhostBaseState
{
    bool isReturning = false;

    private void Resurrect()
    {
        ghost.SetMoveToLocation(resetPos);
        isReturning = true;
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gapTime = 2;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Wait for 1s before setting the next destination
        if (nextActionTime < gapTime)
        {
            nextActionTime += Time.deltaTime;
        }
        else
        {
            if (!isReturning) Resurrect();
        }
    }
}
