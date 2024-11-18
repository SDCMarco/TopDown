using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBT : MonoBehaviour
{
    public HealingSpot healingSpot;
    public Character eroe;
    public BehaviorTree behaviorTree;

    internal void InitializeEnemyController()
    {

        behaviorTree= GetComponent<BehaviorTree>();
      //  behaviorTree.SetVariableValue("Eroe",eroe.gameObject);
        behaviorTree.EnableBehavior();
    }
}
