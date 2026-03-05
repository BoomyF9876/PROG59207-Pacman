using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Escape", story: "[ghost] Escape", category: "Action", id: "ee2beba557586bdf0431dabc42184fea")]
public partial class EscapeAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostController> Ghost;

    protected override Status OnStart()
    {
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

