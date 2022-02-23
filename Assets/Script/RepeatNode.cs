using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatNode : DecoratorNode
{
    protected override void Onstart()
    {
        
    }

    protected override void Onstop()
    {
        
    }
    
    protected override State OnUpdate()
    {
        child.Update();
        return State.Running;
    }
}
