using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasFullLife : Conditional
{
    public override TaskStatus OnUpdate()
    {
        return (gameObject.GetComponent<Character>().hp == gameObject.GetComponent<Character>().hpMax)? TaskStatus.Success : TaskStatus.Failure;
    }
}
