using UnityEngine;

public class PinkyEscapeState : GhostBaseState
{
    private void PinkyEscape()
    {
        prediction = -ghost.PacMan.position;

        ghost.SetMoveToLocation(prediction);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PinkyEscape();
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
            PinkyEscape();
        }
    }
}
