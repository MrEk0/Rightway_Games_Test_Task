using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float speed;
    [SerializeField] float offset = 0.5f;
    [SerializeField] float strength;

    float minX;
    float maxX;

    private void Start()
    {
        CheckScreenBorders();
    }

    // Update is called once per frame
    void Update()
    {
        float horizPosition = Input.GetAxis("Horizontal");
        float posX = transform.position.x + horizPosition * speed * Time.deltaTime;
        posX = Mathf.Clamp(posX, minX, maxX);
        transform.position = new Vector2(posX, transform.position.y);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void CheckScreenBorders()
    {
        Camera cam = Camera.main;
        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+offset;
        maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-offset;
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
    }
}
