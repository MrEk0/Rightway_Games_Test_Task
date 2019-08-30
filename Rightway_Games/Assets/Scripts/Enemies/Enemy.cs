using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy ship", menuName = "Enemy ship")]
public class Enemy : ScriptableObject
{
    [SerializeField] float speed;
    [SerializeField] float timeBetweenShots;
    [SerializeField] float strength;
    [SerializeField] Sprite sprite;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float pointsForDestroying;
    [SerializeField] GameObject path;
    [SerializeField] List<GameObject> laserStartPositions;

    public Sprite GetSprite()
    {
        return sprite;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetTimeShots()
    {
        return timeBetweenShots;
    }

    public float GetStrength()
    {
        return strength;
    }

    public GameObject GetLaser()
    {
        return laserPrefab;
    }

    public float GetPoints()
    {
        return pointsForDestroying;
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();

        foreach (Transform child in path.transform)
        {
            wayPoints.Add(child);
        }

        return wayPoints;
    }

    public List<GameObject> GetLaserPositions()
    {
        return laserStartPositions;
    }
}
