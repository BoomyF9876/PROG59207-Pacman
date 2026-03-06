using System;
using Unity.AppUI.MVVM;
using Unity.AppUI.UI;
using Unity.Behavior;
using Unity.Properties;
using Unity.Services.Analytics;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Escape", story: "[ghost] Escape", category: "Action", id: "ee2beba557586bdf0431dabc42184fea")]
public partial class EscapeAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostController> Ghost;
    private GameObject blinky;
    private float fleeDistance = 8.0f;

    private void BlinkyEscape()
    {
        Ghost.Value.SetMoveToLocation(Ghost.Value.ghostObject.ScatterPos);
    }

    private void ClydeEscape()
    {
        float distance = Vector3.Distance(Ghost.Value.transform.position, Ghost.Value.PacMan.position);

        if (distance > fleeDistance)
        {
            Ghost.Value.SetMoveToLocation(-Ghost.Value.PacMan.position);
        }
        else
        {
            Ghost.Value.SetMoveToLocation(Ghost.Value.ghostObject.ScatterPos);
        }
    }

    private void InkyEscape()
    {
        if (blinky == null)
        {
            blinky = GameObject.Find("Blinky");
        }

        Ghost.Value.SetMoveToLocation(
            Ghost.Value.PacMan.position * 2 - blinky.transform.position
        );
    }

    private void PinkyEscape()
    {
        Ghost.Value.SetMoveToLocation(-Ghost.Value.PacMan.position);
    }

    private void SetGhostEscape()
    {
        switch (Ghost.Value.ghostType)
        {
            case GhostType.Blinky:
                BlinkyEscape(); break;
            case GhostType.Clyde:
                ClydeEscape(); break;
            case GhostType.Inky:
                InkyEscape(); break;
            case GhostType.Pinky:
                PinkyEscape(); break;
        }
    }

    protected override Status OnStart()
    {
        Ghost.Value.agent.SetVariableValue<bool>("isMovingCompleted", false);
        SetGhostEscape();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (
            Ghost.Value.agent.GetVariable<bool>("isDead", out var shouldDie) &&
            Ghost.Value.agent.GetVariable<bool>("isInvincible", out var shouldEscape) &&
            (
                shouldEscape.Value == false ||
                shouldDie.Value == true
            )
        )
        {
            return Status.Success;
        }

        if (
            Ghost.Value.agent.GetVariable<bool>("isMoveCompleted", out var isCompleted) &&
            isCompleted.Value == false
        )
        {
            return Status.Running;
        }

        SetGhostEscape();
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}
