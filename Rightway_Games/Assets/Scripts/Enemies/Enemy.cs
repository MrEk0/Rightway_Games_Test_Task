using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New enemy ship", menuName ="Enemy ship")]
public class Enemy :ScriptableObject
{
    [SerializeField] float strength;
    [SerializeField] Sprite sprite;
    
}
