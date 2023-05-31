using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyWaypoint;
    private bool canSpawn = false;
    public float spawnInterval = 2f; // Time interval between enemy spawns
    public float spawnRadius = 0f; // Maximum distance from the spawner where enemies can spawn

    private float spawnTimer = 0f;

    private bool startRound;

    private void Update()
    {
        // Update the spawn timer
        spawnTimer += Time.deltaTime;

        if (startRound)
        {
            if (spawnTimer + Time.deltaTime == 5f)
            {
                SpawnEnemy();
                spawnTimer = 0f;
                startRound = false;
            }
        }

        if (canSpawn)
        {
            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }
    }

    public void StartSpawning()
    {
        canSpawn = true;
        startRound = true;
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }
    private void SpawnEnemy()
    {
        Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

        GameObject newEnemy = Instantiate(enemyPrefab, this.transform);


        EnemyBehavior enemyMovement = newEnemy.GetComponent<EnemyBehavior>();

        if (enemyMovement != null)
        {
            enemyMovement.enemyWaypoint = enemyWaypoint.transform;
        }
    }


}
