using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Asteroid", menuName ="Asteroid/Create a new asteroid")]
public class Asteroid : ScriptableObject
{
    [SerializeField] float strength;
    [SerializeField] Sprite sprite;
    [SerializeField] float speed;
    [SerializeField] float size;
    [SerializeField] float points;

    public float GetStrength()
    {
        return strength;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public float GetSize()
    {
        return size;
    }
    public float GetPoints()
    {
        return points;
    }
}
