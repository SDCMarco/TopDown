using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBT : MonoBehaviour
{
    public HealingSpot healingSpot;
    public Character eroe;

    internal void InitializeEnemyController()
    {
        GetComponent<BehaviorTree>().EnableBehavior();
    }
}
