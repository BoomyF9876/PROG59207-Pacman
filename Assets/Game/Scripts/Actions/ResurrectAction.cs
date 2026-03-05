using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Resurrect", story: "[ghost] Resurrect", category: "Action", id: "9ca0f161a20c2318e624f22cc3d628a9")]
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
        Ghost.Value.ResetSpeed();
    }
}
