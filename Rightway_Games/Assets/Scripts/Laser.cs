using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //[SerializeField] float damage = 10;
    [SerializeField] float speed = 10;

    Rigidbody2D rd;
    Vector2 speedVector;

    public float Damage {private get;  set; }

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        speedVector = new Vector2(0, speed);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rd.velocity = speedVector;
    }
}
