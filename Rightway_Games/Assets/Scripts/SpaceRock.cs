﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRock : MonoBehaviour
{
    [SerializeField] Asteroid asteroidType;
    [SerializeField] float rotateSpeed;
    [SerializeField] float speedDivider;

    Rigidbody2D rd;
    float speed;
    Vector3 rotate;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        speed = asteroidType.GetSpeed()/speedDivider;
        rotate = new Vector3(0, 0, rotateSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate*Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rd.velocity = new Vector2(0, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Damage");
            Destroy(gameObject);
        }
    }
}