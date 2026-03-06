using UnityEngine;

public class BlinkyChaseState : GhostBaseState
{
    private void BlinkyChase()
    {
        ghost.SetMoveToLocation(ghost.PacMan.position);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BlinkyChase();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Wait for gapTime seconds before setting the next destination
        if (nextActionTime < gapTime)
        {
            nextActionTime += Time.deltaTime;
        }
        else
        {
            nextActionTime = 0;
            BlinkyChase();
        }
    }
}
