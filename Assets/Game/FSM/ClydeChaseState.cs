using UnityEngine;

public class ClydeChaseState : GhostBaseState
{
    public float fleeDistance = 8.0f;

    private void ClydeChase()
    {
        float distance = Vector3.Distance(ghost.transform.position, ghost.PacMan.position);

        if (distance > fleeDistance)
        {
            ghost.SetMoveToLocation(ghost.PacMan.position);
        }
        else
        {
            ghost.SetMoveToLocation(scatterPos);
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ClydeChase();
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
            nextActionTime = 0;
            ClydeChase();
        }
    }
}
