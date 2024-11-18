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


        EnemyController enemyController = enemyGO.GetComponent<EnemyController>();
        enemyController.eroe = eroe;
        enemyController.healingSpot = healingSpot;
        enemyController.target = eroe.gameObject.transform;

        enemyController.InitializeEnemyController();

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
        InvokeRepeating(nameof(SpawnEnemyIfTheyAreNotTooMany), timeBetweenEnemiesSpawn, timeBetweenEnemiesSpawn);
    }
    //
}
