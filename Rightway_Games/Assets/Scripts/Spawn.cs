using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] List<GameObject> commetsToSpawn;
    [SerializeField] List<GameObject> enemiesToSpawn;
    [SerializeField] List<GameObject> powerUpToSpawn;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float offset = 0.5f;
    [SerializeField] int maxEnemies = 5;
    [SerializeField] float chanceOfEnemy = 30f;
    [SerializeField] float chanceOfRock = 60f;

    List<GameObject> prefabsToSpawn = new List<GameObject>();
    float timeSinceLastSpawn = 0f;
    float minX;
    float maxX;
    int enemyCount = 0;

    private void Start()
    {
        CheckScreenBorders();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastSpawn > timeBetweenSpawns)
        {
            SpawnObjects();
            timeSinceLastSpawn = 0f;
        }
        timeSinceLastSpawn += Time.deltaTime;
    }

    private void CheckScreenBorders()
    {
        Camera cam = Camera.main;
        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + offset;
        maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - offset;
    }

    private void SpawnObjects()
    {
        int rand = Random.Range(0, 100);

        if (rand < chanceOfRock)
        {
            prefabsToSpawn = commetsToSpawn;
        }
        else if (rand < chanceOfEnemy+chanceOfRock && enemyCount < maxEnemies)
        {
            prefabsToSpawn = enemiesToSpawn;
            enemyCount++;
        }
        else
        {
            prefabsToSpawn = powerUpToSpawn;
        }

        int randomObjectIndex = Random.Range(0, prefabsToSpawn.Count);
        float randomPositionX = Random.Range(minX, maxX);

        Vector3 startPosition = new Vector3(randomPositionX, transform.position.y, transform.position.z);

        GameObject prefab = Instantiate(prefabsToSpawn[randomObjectIndex], startPosition, transform.rotation, transform);

        if(prefabsToSpawn==enemiesToSpawn)
        {
            prefab.GetComponent<EnemyShip>().onDead += UpdateEnemyCount;
        }
    }

    private void UpdateEnemyCount()
    {
        enemyCount--;
    }
}
