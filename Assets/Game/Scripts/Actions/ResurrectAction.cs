using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Resurrect", story: "[ghost] Die", category: "Action", id: "dffb0dee4a54cbfbfae1dbed471369ef")]
public partial class ResurrectAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostController> Ghost;

    protected override Status OnStart()
    {
        Ghost.Value.Resurrect();
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

