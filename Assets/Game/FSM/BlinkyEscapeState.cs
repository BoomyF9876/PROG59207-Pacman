using UnityEngine;

public class BlinkyEscapeState : GhostBaseState
{
    private void BlinkyEscape()
    {
        ghost.SetMoveToLocation(scatterPos);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Moving to static location, so no OnStateUpdate needed
        BlinkyEscape();
    }
}
