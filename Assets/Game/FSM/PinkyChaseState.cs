using UnityEngine;

public class PinkyChaseState : GhostBaseState
{
    private void PinkyChase()
    {
        prediction = pacman.MoveDirections[(int)pacman.moveDirection];

        ghost.SetMoveToLocation(
            ghost.PacMan.position +
            new Vector3(prediction.x, prediction.y, 0) * 4
        );
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PinkyChase();
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
            PinkyChase();
        }
    }
}
