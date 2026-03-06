using UnityEngine;

public class InkyChaseState : GhostBaseState
{
    GameObject blinky;

    private void InkyChase()
    {
        if (blinky == null)
        {
            blinky = GameObject.Find("Blinky");
        }

        prediction = pacman.MoveDirections[(int)pacman.moveDirection];

        ghost.SetMoveToLocation(
            (ghost.PacMan.position + new Vector3(prediction.x, prediction.y, 0) * 2) * 2 -
            blinky.transform.position
        );
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        InkyChase();
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
            InkyChase();
        }
    }
}
