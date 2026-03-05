using System;
using Unity.AppUI.MVVM;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Escape", story: "[ghost] Escape", category: "Action", id: "ee2beba557586bdf0431dabc42184fea")]
public partial class EscapeAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostController> Ghost;

    protected override Status OnStart()
    {
        switch (Ghost.Value.ghostType)
        {
            case GhostType.Blinky:
                Ghost.Value.SetMoveToLocation(Ghost.Value.ghostObject.ScatterPos);
                break;
            case GhostType.Clyde:
                break;
            case GhostType.Inky:
                break;
            case GhostType.Pinky:
                break;
        }
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        switch (Ghost.Value.ghostType)
        {
            case GhostType.Blinky:

                break;
            case GhostType.Clyde:
                break;
            case GhostType.Inky:
                break;
            case GhostType.Pinky:
                break;
        }


        Ghost.Value.SetMoveToLocation(Ghost.Value.ghostObject.ResetPos);

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}
