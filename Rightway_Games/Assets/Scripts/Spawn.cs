using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabsToSpawn;
    [SerializeField] float timeBetweenSpawns;

    float timeSinceLastSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
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

    private void SpawnObjects()
    {
        int randomObjectIndex = Random.Range(0, prefabsToSpawn.Count);

        Instantiate(prefabsToSpawn[randomObjectIndex], transform.position, transform.rotation);
    }
}
