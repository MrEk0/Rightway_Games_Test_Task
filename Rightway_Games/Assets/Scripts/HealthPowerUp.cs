using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float strengthAmount;

    Rigidbody2D rd;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //get power up
            collision.gameObject.GetComponent<Player>().ReceivePowerUp(strengthAmount);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rd.velocity = Vector2.down * speed/2;
    }
}
