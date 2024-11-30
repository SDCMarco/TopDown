using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public HealingSpot healingSpot;
    public Character eroe;
    public Transform target;
    public NavMeshAgent navMeshAgent;
    public float refreshDestinationRate = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
       // InitializeEnemyController();

    }

    public void InitializeEnemyController()
    {


        navMeshAgent = GetComponent<NavMeshAgent>();

        InvokeRepeating(nameof(UpdateDestination), refreshDestinationRate, refreshDestinationRate);
    }

    private void DecideDestination(float hp, float hpMax)
    {
        /* */
        
        float hpRatio = hp / hpMax;
        if (hpRatio < 0.5f)
        {
         //   healingSpot = FindObjectOfType<HealingSpot>();
            target = healingSpot.gameObject.transform;
        }
        else
        {
            target = eroe.gameObject.transform;
        }
    //    target = (hp / hpMax < 0.5f) ? healingSpot.gameObject.transform : eroe.gameObject.transform;
    }

    private void EnemyChangeColorBasedOnHp(float hp, float hpMax)
    {
        float hpRatio = hp / hpMax;
        Color newColor = Color.red * hpRatio;
        GetComponent<MeshRenderer>().material.color = newColor;
    }

    private void EnemyDeath()
    {
        Destroy(gameObject);
    }

    private void Update()
    {

    }

    private void UpdateDestination()
    {
        navMeshAgent.destination = target.position;
    }
}
