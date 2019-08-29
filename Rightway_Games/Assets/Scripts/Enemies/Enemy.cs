using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy ship", menuName = "Enemy ship")]
public class Enemy : ScriptableObject
{
    [SerializeField] float strength;
    [SerializeField] Sprite sprite;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float pointsForDestroying;
    [SerializeField] GameObject path;

    public Sprite GetSprite()
    {
        return sprite;
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

    //public GameObject GetPath()
    //{
    //    return path;
    //}

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();

        foreach (Transform trans in path.transform)
        {
            wayPoints.Add(trans);
        }

        return wayPoints;
    }
}
