using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyPrefab;
    public float timeBetweenEnemiesSpawn=2;
    public int maxEnemiesAllowedOnTheMap = 10;

    public Character eroe;
    public HealingSpot healingSpot;

    

    public void SpawnEnemy()
    {
        GameObject enemyGO = Instantiate(enemyPrefab, spawnPoint.position,spawnPoint.rotation);


        EnemyControllerBT enemyController = enemyGO.GetComponent<EnemyControllerBT>();
        enemyController.eroe = eroe;
        enemyController.healingSpot = healingSpot;
        enemyController.InitializeEnemyController(healingSpot);

    }



    public void SpawnEnemyIfTheyAreNotTooMany() 
    {
        if (FindObjectsOfType<EnemyController>().Length  < maxEnemiesAllowedOnTheMap)
        {
            SpawnEnemy();
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemyIfTheyAreNotTooMany), 0, timeBetweenEnemiesSpawn);
    }
    //
}
