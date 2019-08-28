using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
        }
    }
}
