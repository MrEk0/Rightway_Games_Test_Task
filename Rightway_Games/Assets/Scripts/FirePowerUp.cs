using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePowerUp : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeFrame;

    Rigidbody2D rd;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().ModifierFire(timeFrame);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rd.velocity = Vector2.down * speed / 2;
    }
}
