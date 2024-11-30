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

    internal void InitializeEnemyController(HealingSpot healingSpot)
    {
        Character character = GetCharacter();
        character.OnCharacterDeath.AddListener(EnemyDeath);
        character.OnHpChange.AddListener(EnemyChangeColorBasedOnHp);

        behaviorTree = GetComponent<BehaviorTree>();
        behaviorTree.SetVariableValue("HealingSpot", healingSpot.gameObject);
        behaviorTree.EnableBehavior();
    }
    public Character GetCharacter()
    {
        return GetComponent<Character>();
    }
    private void EnemyDeath()
    {
        Destroy(gameObject);
    }
    private void EnemyChangeColorBasedOnHp(float hp, float hpMax)
    {
        float hpRatio = hp / hpMax;
        Color newColor = Color.red * hpRatio;
        GetComponent<MeshRenderer>().material.color = newColor;
    }


}
