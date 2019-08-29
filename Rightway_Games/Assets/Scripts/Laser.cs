using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float speed = 10;

    Rigidbody2D rd;
    Vector2 speedVector;

    public float Damage { get;  set; }

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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyLaser"))
    //    {
    //        collision.gameObject.GetComponent<Player>().TakeDamage(Damage);
    //    }
    //    else if(collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Laser"))
    //    {
    //        collision.gameObject.GetComponent<EnemyShip>().Health -= Damage;
    //        Debug.Log("Damage");
    //    }
    //}
}
