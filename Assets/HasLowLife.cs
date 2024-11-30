using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasLowLife : Conditional
{
    public override TaskStatus OnUpdate()
    {
        Character character = gameObject.GetComponent<Character>();
        float hpRatio = character.hp / character.hpMax;
        if (hpRatio >= 0.5f)
        {
            return TaskStatus.Failure;
        }
        else
        {
            return TaskStatus.Success;
        }

    }

}
