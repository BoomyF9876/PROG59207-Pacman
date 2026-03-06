using System;
using Unity.AppUI.MVVM;
using Unity.AppUI.UI;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "[ghost] chase", category: "Action", id: "587c0ab5640f12a3b31738fe9386dbfd")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostController> Ghost;
    private GameObject blinky;
    private float fleeDistance = 8.0f;

    private void BlinkyChase()
    {
        Ghost.Value.SetMoveToLocation(Ghost.Value.PacMan.position);
    }

    private void ClydeChase()
    {
        float distance = Vector3.Distance(Ghost.Value.transform.position, Ghost.Value.PacMan.position);

        if (distance > fleeDistance)
        {
            Ghost.Value.SetMoveToLocation(Ghost.Value.PacMan.position);
        }
        else
        {
            Ghost.Value.SetMoveToLocation(Ghost.Value.ghostObject.ScatterPos);
        }
    }

    private void InkyChase()
    {
        if (blinky == null)
        {
            blinky = GameObject.Find("Blinky");
        }

        Ghost.Value.ghostObject.Prediction = Ghost.Value.ghostObject.Pacman.MoveDirections[(int)Ghost.Value.ghostObject.Pacman.moveDirection];

        Ghost.Value.SetMoveToLocation(
            (Ghost.Value.PacMan.position + new Vector3(Ghost.Value.ghostObject.Prediction.x, Ghost.Value.ghostObject.Prediction.y, 0) * 2) * 2 -
            blinky.transform.position
        );
    }

    private void PinkyChase()
    {
        Ghost.Value.ghostObject.Prediction = Ghost.Value.ghostObject.Pacman.MoveDirections[(int)Ghost.Value.ghostObject.Pacman.moveDirection];

        Ghost.Value.SetMoveToLocation(
            Ghost.Value.PacMan.position +
            new Vector3(Ghost.Value.ghostObject.Prediction.x, Ghost.Value.ghostObject.Prediction.y, 0) * 4
        );
    }

    private void SetGhostChase()
    {
        switch (Ghost.Value.ghostType)
        {
            case GhostType.Blinky:
                BlinkyChase(); break;
            case GhostType.Clyde:
                ClydeChase(); break;
            case GhostType.Inky:
                InkyChase(); break;
            case GhostType.Pinky:
                PinkyChase(); break;
        }
    }

    protected override Status OnStart()
    {
        Ghost.Value.agent.SetVariableValue<bool>("isMovingCompleted", false);
        SetGhostChase();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (
            Ghost.Value.agent.GetVariable<bool>("isMoveCompleted", out var isCompleted) &&
            Ghost.Value.agent.GetVariable<bool>("isInvincible", out var shouldEscape) &&
            Ghost.Value.agent.GetVariable<bool>("isDead", out var shouldDie) &&
            (
                isCompleted.Value == true ||
                shouldEscape.Value == true ||
                shouldDie.Value == true
            )
        )
        {
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}
