using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasLowLife : Conditional
{
    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Success;
    }

}
