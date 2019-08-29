using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New enemy ship", menuName ="Enemy ship")]
public class Enemy :ScriptableObject
{
    [SerializeField] float strength;
    [SerializeField] Sprite sprite;
    [SerializeField] GameObject laserPrefab;
    
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
}
