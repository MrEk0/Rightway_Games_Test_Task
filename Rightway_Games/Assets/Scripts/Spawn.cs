using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabsToSpawn;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float offset = 0.5f;

    float timeSinceLastSpawn = 0f;
    float minX;
    float maxX;

    private void Start()
    {
        CheckScreenBorders();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceLastSpawn>timeBetweenSpawns)
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
        int randomObjectIndex = Random.Range(0, prefabsToSpawn.Count);
        float randomPositionX = Random.Range(minX, maxX);

        Debug.Log(randomPositionX);
        Debug.Log(maxX);

        Vector3 startPosition = new Vector3(randomPositionX, transform.position.y, transform.position.z);

        Instantiate(prefabsToSpawn[randomObjectIndex], startPosition, transform.rotation);
    }
}
