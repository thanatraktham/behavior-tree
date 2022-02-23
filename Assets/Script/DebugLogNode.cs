using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogNode : ActionNode
{
    public string message;

    protected override void Onstart()
    {
        Debug.Log($"OnStart{message}");
    }

    protected override void Onstop()
    {
        Debug.Log($"OnStop{message}");
    }
    protected override State OnUpdate()
    {
        Debug.Log($"OnUpdate{message}");
        return State.Success;
    }
}
