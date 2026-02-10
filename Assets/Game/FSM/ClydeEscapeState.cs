using UnityEngine;

public class ClydeEscapeState : GhostBaseState
{
    private void Scatter()
    {
        ghost.SetMoveToLocation(scatterPos);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Scatter();
    }
}
