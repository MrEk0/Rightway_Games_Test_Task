using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;


    // Update is called once per frame
    void Update()
    {
        float horizPosition = Input.GetAxis("Horizontal");
        float Xpos = transform.position.x + horizPosition * speed * Time.deltaTime;
        transform.position = new Vector2(Xpos, transform.position.y);
    }
}
