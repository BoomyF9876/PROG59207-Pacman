using UnityEngine;
using System.Collections;

public class GhostDeathState : GhostBaseState
{
    bool isReturning = false;

    private void Resurrect()
    {
        ghost.SetMoveToLocation(resetPos);
        ghost.pathCompletedEvent += BackToNormal;
        isReturning = true;
    }

    private void BackToNormal()
    {
        // Stay in base for gapTime seconds then return to patrol
        ghost.StartCoroutine(WaitForSeconds(gapTime));
    }

    IEnumerator WaitForSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        ghost.Resurrect();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gapTime = 2.0f;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stand still for gapTime seconds then go the base
        if (nextActionTime < gapTime)
        {
            nextActionTime += Time.deltaTime;
        }
        else
        {
            if (!isReturning) Resurrect();
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        ghost.moveCompletedEvent -= BackToNormal;
    }
}
