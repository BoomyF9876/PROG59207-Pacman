using UnityEngine;

public class ClydeEscapeState : GhostBaseState
{
    public float fleeDistance = 8.0f;

    private void ClydeEscape()
    {
        float distance = Vector3.Distance(ghost.transform.position, ghost.PacMan.position);

        if (distance > fleeDistance)
        {
            ghost.SetMoveToLocation(-ghost.PacMan.position);
        }
        else
        {
            ghost.SetMoveToLocation(scatterPos);
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ClydeEscape();
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
            ClydeEscape();
        }
    }
}
