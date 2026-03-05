using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Die", story: "[ghost] Die", category: "Action", id: "dffb0dee4a54cbfbfae1dbed471369ef")]
public partial class DieAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostController> Ghost;
    protected override Status OnStart()
    {
        Ghost.Value.speed = 0.05f;
        Ghost.Value.SetMoveToLocation(Ghost.Value.ghostObject.ResetPos);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}
